using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        public GameObject ObjetoAPoner;
        public GameObject ObjetoAPonerAux;
        public ARPlaneManager planeManager;
        public Animator animator;

        UnityEvent placementUpdate;

        [SerializeField]
        GameObject visualObject;
        Pose hitPose;
        public GameObject spawnedObject { get; private set; }
        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            planeManager = GetComponent<ARPlaneManager>();

            if (placementUpdate == null)
                placementUpdate = new UnityEvent();

                placementUpdate.AddListener(DiableVisual);
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;
            return false;
        }

        void Update(){
            if(animator.GetBool("cerrado")==true){
                if(ObjetoAPonerAux == ObjetoAPoner || spawnedObject == null){
                    if (!TryGetTouchPosition(out Vector2 touchPosition))
                        return;
                    if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon)){
                        hitPose = s_Hits[0].pose;
                        if (spawnedObject == null) {
                            spawnedObject = Instantiate(ObjetoAPoner, hitPose.position, hitPose.rotation);
                            StopPlaneDetection();
                        }
                        placementUpdate.Invoke();
                    }
                }else{
                    sustituir();
                }
                ObjetoAPonerAux = ObjetoAPoner;
            }

        }
        public void sustituir(){
            Destroy(spawnedObject);
            spawnedObject = Instantiate(ObjetoAPoner, hitPose.position, hitPose.rotation);
        }
        public void StopPlaneDetection(){
            if (planeManager != null){
                planeManager.enabled = false;
            }
        }
        public void removePlanes(){
            foreach (var plane in planeManager.trackables){
                plane.gameObject.SetActive(false);
            }
        }
        public void reiniciar(){
            Destroy(spawnedObject);
            planeManager.enabled = true;
        }
        public void removeObject(){
            Destroy(spawnedObject);
        }
        public void DiableVisual(){
            visualObject.SetActive(false);
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }