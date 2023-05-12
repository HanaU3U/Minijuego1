using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    // Este es el script q lee el archivo Json con la data

    /* Estructura del Json Ejemplo: 
    
    {
    "preguntas" : [
        {
        "nombre": "Geografía",
		"id": 1,
		"preguntas": [
			{
				"id:":1,
				"pregunta": "El Río Nilo se encuentra en África",
				"opciones": "Verdadero* || Falso"
			},
            ...
        },
        ...
    ]
    }

    */

    // Primero se toma el Json como un TextAsset
    public TextAsset jsonText;

    /* Ahora creo las clases q representan los Datos del Json, uso [System.Serializable] 
    pues hay q guardar esos datos */

    [System.Serializable]
    public class PreguntasGrupo {
        public string nombre; // nombres de variables iguales al Json pa evitar errores
        public int id;
        public Preguntas[] preguntas;
    }

    [System.Serializable]
    public class Preguntas {
        public int id;
        public string pregunta;
        public string opciones;
    }

    // Ahora creo otra... clase q sirva como lista de las preguntas (seh con [System.Serializable])

    [System.Serializable]
    public class ListaPreguntas {
        public PreguntasGrupo[] preguntas; // El array se ha de llamar igual q en el Json
    }
    
    // Creo la lista de preguntas para luego añadir las del Json

    public ListaPreguntas qst = new ListaPreguntas();

    private void Awake() {
        // Ahora con todo listo leo el Json (con la funcion propia) para poder usarlo como plazca
        LeerData();
    }

    // Funcion q lee el Json Y q se puede usar en el editor de Unity (es para testear todo mejor)
    [ContextMenu("Leer Data")] // Esto es para poder usarlo en cualquier momento dentro del editor
    public void LeerData() {
        qst = JsonUtility.FromJson<ListaPreguntas>(jsonText.text);
    }

    /* Funcion q da la info de qst como Json en String Y q se puede usar en el editor de Unity 
    (es para testear todo mejor)*/
    [ContextMenu("Save")] // Esto es para poder usarlo en cualquier momento dentro del editor
    public void Guardar() {
        string info = JsonUtility.ToJson(qst);
        Debug.Log(info);
    }

}
