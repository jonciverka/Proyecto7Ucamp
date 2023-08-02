using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPoner : MonoBehaviour
{

    public bool prendido = false;
    private GameObject gameControllerGO;
    private GameController gameController;
    public GameObject objetoAPoner;
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameControllerGO = GameObject.FindWithTag("GameController");
        gameController = gameControllerGO.GetComponent<GameController>();
    }
    // Update is called once per frame
    void pres(){
        gameController.accion(objetoAPoner);
        prendido = true;
        animator.SetBool("esAbierto",false);




        // GameObject[] buttons = GameObject.FindGameObjectsWithTag("Bottom");
        // Color color;

        // foreach(GameObject  button in buttons){
        //     if (ColorUtility.TryParseHtmlString("#FFF", out color))
        //     {
        //         button.GetComponent<Image>().color = color;
        //     }
        //     else
        //     {
        //         Debug.LogError("Error al convertir el color hexadecimal: " + "#FFF");
        //     }
        // }

        
        // if (ColorUtility.TryParseHtmlString("#B0B0B0", out color))
        // {
        //     GetComponent<Image>().color = color;
        // }
        // else
        // {
        //     Debug.LogError("Error al convertir el color hexadecimal: " + "#B0B0B0");
        // }
    }
}
