using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
   
    // *Nota: Sorry por la horrografia, yo uso '_' para varibles privadas (cosas aprendidas de Python)
    // Variables, Objetos (referencias a los de la esena*)

    /*SerializeField es para q Unity me muestre en el editor aunque sean privados (Probando cosas, varibles,
    objetos, referencias, etc, ;) ) Aunque se pueden usar como publicos tambien, aunque de esta forma el objeto
    esta mas aislado y con menos riesgo de bugs.*/

    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    // Para el fondo no se nesesita un Start

    // Update is called once per frame
    void Update()
    {
        /* El fondo es un 'RawImage' pues asi se puede hacer mover la textura por frame (si esta con metodo 
        WrapMode en Repeat) sin que que se joda la relacion de aspecto ni su posicion */

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}
