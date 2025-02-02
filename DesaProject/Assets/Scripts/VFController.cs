using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VFController : MonoBehaviour
{
    // Este es el Script q maneja la logica de las preguntas VF, Cambio, Verificacion ETC

    // Estos son los Atributos, las referencias para q funcione
    [SerializeField] private GameObject _question;
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private JsonReader _questionList;

    // Aqui es para los generos de las preguntas
    public TopicController generosObject;
    private List<int> _generosPregutas = new List<int>(6); // Nota cada objeto es el id del genero -1

    // Estos son los parametros q indican q genro tiene la pregunta actual y su id (ambos - 1)
    private int _qstTopic;
    private int _qstNum;

    // Por ultimo el check y su animator
    public GameObject check;
    private Animator _checkAnimator;

    // Uso el awake para consegir el texto de la pregunta y las posibles preguntas
    void Awake() {
        // Primero tomo el TMP (text mesh Pro) de la pregunta para luego cambiarlo
        _questionText = _question.GetComponentInChildren<TMP_Text>();

        // Luego tomo el array de preguntas leidas de Json
        _questionList = _question.GetComponent<JsonReader>();

        // Se toma el animator del check
        _checkAnimator = check.GetComponent<Animator>();
    }

    // Funcion q actualiza los generos escojidos se ejecuta al cambiar de pantallas
    public void UpdateTopics() {
        for (int i = 0; i < generosObject.generosEscojidos.Count; i ++) {
            _generosPregutas.Add(generosObject.generosEscojidos[i]);
        }
    }

    // Esta es la funcion q se ejecuta al dar click en el boton (Cambia a una pregunta del Json)
    public void ChangeQuestionVF() {
        // Primero se escoje uno de los generos seleccionados
        int tempRand = Random.Range(0, _generosPregutas.Count);
        _qstTopic = _generosPregutas[tempRand];

        // Genero un random q sera el numero de la preunta del Genero (obio en rango de la cantidad de preguntas)
        _qstNum = Random.Range(0, _questionList.qst.preguntas[_generosPregutas[_qstTopic]].preguntas.Length);

        // Para luego cambiar el texto q se muestra
        _questionText.text = _questionList.qst.preguntas[_generosPregutas[_qstTopic]].preguntas[_qstNum].pregunta;

        // Y dar la respuesta por consola (pa confirmar de momento)
        Debug.Log("Respuesta: " + GetAnswerVF(_generosPregutas[_qstTopic], _qstNum));
    }

    // Esta funcion regresa si la respuesta correcta es verdadero o falso (True or False)
    public bool GetAnswerVF(int topic, int num) {
        // Primero separamos el string de respuesta en un array
        string[] answers = _questionList.qst.preguntas[topic].preguntas[num].opciones.Split(" || ");

        // Ahora se busca por el '*' q denota la respuesta correcta
        int i = 0; // denotador de si es 'V' o 'F'
        string search = "*"; // Caracter a buscar

        // el foreach con el if revisan si es el primero o segundo string el q tiene como ultimo caracter '*'
        foreach (string x in answers) {
            if (search.Contains(x.Substring(x.Length - 1))) {
                if (i == 0) { // Regresa q la respuesta es 'V'
                    return true;
                } else { // Regresa q la respuesta es 'F'
                    return false;
                }
            }

            i ++; // aumenta el denotador para segir evaluando
        }

        return  false; // Para q la funcion no pete (pero nunca llegara a el)
    }

    // Esta es la funcion q ocurre cuando se le da click en V o F para cambiar y dar el feedback
    public void CheckAnswer(bool answer) {
        if (answer == GetAnswerVF(_generosPregutas[_qstTopic], _qstNum)) {
            _checkAnimator.SetBool("Right", true);
            _checkAnimator.SetTrigger("Start");
            check.SetActive(true);
        } else {
            _checkAnimator.SetBool("Right", false);
            _checkAnimator.SetTrigger("Start");
            check.SetActive(true);
        }

        _checkAnimator.SetTrigger("Start");

        ChangeQuestionVF();
    }
}
