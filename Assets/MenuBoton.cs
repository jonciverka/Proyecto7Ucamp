using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBoton : MonoBehaviour
{
    public Sprite  abierto;
    public Sprite  cerrado;
    public Animator animator;
    public GameObject botonImage;

    // Update is called once per frame
    public void accion()
    {
        animator.SetBool("cerrado",false);

        if(animator.GetBool("esAbierto")){
            animator.SetBool("esAbierto",false);
            botonImage.GetComponent<Image>().sprite = cerrado;
        }else{
            botonImage.GetComponent<Image>().sprite = abierto;
            animator.SetBool("esAbierto",true);
        }
    }
    public int setCerrado(int a){
        animator.SetBool("cerrado",true);
        return a;
    }
}
