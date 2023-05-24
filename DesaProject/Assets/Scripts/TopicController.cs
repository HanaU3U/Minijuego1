using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicController : MonoBehaviour
{
    // Controllador de los generos escojidos 

    // Primero la lista con los id de los generos (id -1)
    
    public List<int> generosEscojidos;

    // Funciones dinamicas para cada genero

    public void ChangeGeografia (bool estado) {
        generosEscojidos.RemoveAll(i => i == 0);
        if (estado) {
            generosEscojidos.Add(0);
        }
    }

    public void ChangeHistoria (bool estado) {
        generosEscojidos.RemoveAll(i => i == 1);
        if (estado) {
            generosEscojidos.Add(1);
        }
    }

    public void ChangeCiencia (bool estado) {
        generosEscojidos.RemoveAll(i => i == 2);
        if (estado) {
            generosEscojidos.Add(2);
        }
    }

    public void ChangeDeportes (bool estado) {
        generosEscojidos.RemoveAll(i => i == 3);
        if (estado) {
            generosEscojidos.Add(3);
        }
    }

    public void ChangeAniManga (bool estado) {
        generosEscojidos.RemoveAll(i => i == 4);
        if (estado) {
            generosEscojidos.Add(4);
        }
    }

    public void ChangeVideoJuegos (bool estado) {
        generosEscojidos.RemoveAll(i => i == 5);
        if (estado) {
            generosEscojidos.Add(5);
        }
    }

}
