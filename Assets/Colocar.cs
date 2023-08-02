using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class Colocar : MonoBehaviour
{
    public ARPlaneManager miPlaneManager;
    public GameObject miModeloPrefab;
    List<ARPlane> planes = new List<ARPlane>();
    private GameObject miModeloPuesto;
    private void OnEnable(){
        miPlaneManager.planesChanged += PlanesFound;
    }

    private void OnDisable(){
        miPlaneManager.planesChanged -= PlanesFound;
    }

    void PlanesFound(ARPlanesChangedEventArgs infoPlane){
        if(infoPlane.added != null && infoPlane.added.Count > 0){
            planes.AddRange(infoPlane.added); 
        }
        foreach(var plane in planes){
            if(plane.extents.x * plane.extents.y >= 0.5 && miModeloPuesto == null){
                miModeloPuesto = Instantiate(miModeloPrefab);
                miModeloPuesto.transform.position = new Vector3(plane.center.x,plane.center.y,plane.center.z);
                StopDetection();
            }
        }
    }
    void StopDetection(){
        miPlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
        foreach(var plane in planes){
            plane.gameObject.SetActive(false);
        }
    }



}
