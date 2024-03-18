using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainAudioMixer; // Referência ao AudioMixer

    private bool isAudioMuted = false; // Estado atual do áudio

    // Método para ligar/desligar o áudio ao clicar no botão
    public void ToggleAudio()
    {
        isAudioMuted = !isAudioMuted; // Inverte o estado do áudio

        // Define o volume para todos os grupos de áudio no AudioMixer
        if (isAudioMuted)
        {
            // Desliga o áudio, definindo o volume de todos os grupos para -80 dB (silenciado)
            mainAudioMixer.SetFloat("MasterVolume", -80f);
            mainAudioMixer.SetFloat("MusicVolume", -80f);
            mainAudioMixer.SetFloat("SFXVolume", -80f);
            // Adicione mais linhas conforme necessário para outros grupos de áudio
        }
        else
        {
            // Liga o áudio, definindo o volume de todos os grupos de volta para 0 dB (normal)
            mainAudioMixer.SetFloat("MasterVolume", 0f);
            mainAudioMixer.SetFloat("MusicVolume", 0f);
            mainAudioMixer.SetFloat("SFXVolume", 0f);
            // Adicione mais linhas conforme necessário para outros grupos de áudio
        }
    }
}
