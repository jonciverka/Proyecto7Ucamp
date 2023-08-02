using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject placeOnPlane;

    private GameObject objetoAux;


    public void accion(GameObject objeto){
        if(objeto==objetoAux){
            quitarObjecto();
        }else{
            setObjectoAPoner(objeto);
        }
        objetoAux = objeto;

    }

    public void setObjectoAPoner(GameObject objeto){
        placeOnPlane.GetComponent<PlaceOnPlane>().ObjetoAPoner = objeto;
    }
    public void quitarObjecto(){
        placeOnPlane.GetComponent<PlaceOnPlane>().removeObject();
    }
    
}
