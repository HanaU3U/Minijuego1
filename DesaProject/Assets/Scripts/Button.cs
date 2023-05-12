using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Button : MonoBehaviour, IPointerDownHandler
{
    // Este es el script del boton es para q tengan funcionalidades extra, como tener sonido

    /* Seh vuelvo a usar SerializeField para tener bien aisladito el script, de paso 
    me cargo el update pues no me serve aqui */
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioSource _source;

    // Esta funcion toda 'rara' es para cuando se de click suene
    public void OnPointerDown(PointerEventData eventData) {
        _source.PlayOneShot(_clickSound);
    }

    // Esta funcion es para el boton Quit, solo sirve una vez exportado el juego
    public void Quit() {
        Application.Quit();
        Debug.Log("Se cerro el juego"); // Mientras para testear
    }

}