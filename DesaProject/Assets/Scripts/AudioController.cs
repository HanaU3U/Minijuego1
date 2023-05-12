using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    // Este es el script q maneja el audio con el slider

    // Primero tomamos el Mixer y seteamos los canales a modificar
    [SerializeField] private AudioMixer _mixer; // Con el [serialize] por seguridad
    const string masterChannel = "MasterVolume";
    const string musicChannel = "MusicVolume";
    const string SFXChannel = "SFXVolume";
    
    // Ahora las funciones q cambian el audio, nota se usa log pues el sonido es logaritmico

    // Master
    public void SetMasterVolume(float sliderValue) {
        _mixer.SetFloat(masterChannel, Mathf.Log10(sliderValue) * 20);
    }
    
    // Music
    public void SetMusicVolume(float sliderValue) {
        _mixer.SetFloat(musicChannel, Mathf.Log10(sliderValue) * 20);
    }

    // SFX
    public void SetSFXVolume(float sliderValue) {
        _mixer.SetFloat(SFXChannel, Mathf.Log10(sliderValue) * 20);
    }

}
