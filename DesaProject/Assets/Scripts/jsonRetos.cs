using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonRetos : MonoBehaviour
{
    public TextAsset jsonText;

    /* Ahora creo una clase q representa los Datos del Json, uso [System.Serializable] 
    pues hay q guardar esos datos */

    [System.Serializable]
    public class Reto {
        public string retos; // nombres de variables iguales al Json pa evitar errores
    }

    // Ahora creo otra... clase q sirva como lista de las preguntas (seh con [System.Serializable])

    [System.Serializable]
    public class RetoList {
        public retosBETA[] retos; // El array se ha de llamar igual q en el Json
    }

    // Creo la lista de preguntas para luego añadir las del Json

    public RetoList retos = new RetoList();

    void Start()
    {
        retos = JsonUtility.FromJson<RetoList>(jsonText.text);
    }

}
