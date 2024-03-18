using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainAudioMixer; // Refer�ncia ao AudioMixer

    private bool isAudioMuted = false; // Estado atual do �udio

    // M�todo para ligar/desligar o �udio ao clicar no bot�o
    public void ToggleAudio()
    {
        isAudioMuted = !isAudioMuted; // Inverte o estado do �udio

        // Define o volume para todos os grupos de �udio no AudioMixer
        if (isAudioMuted)
        {
            // Desliga o �udio, definindo o volume de todos os grupos para -80 dB (silenciado)
            mainAudioMixer.SetFloat("MasterVolume", -80f);
            mainAudioMixer.SetFloat("MusicVolume", -80f);
            mainAudioMixer.SetFloat("SFXVolume", -80f);
            // Adicione mais linhas conforme necess�rio para outros grupos de �udio
        }
        else
        {
            // Liga o �udio, definindo o volume de todos os grupos de volta para 0 dB (normal)
            mainAudioMixer.SetFloat("MasterVolume", 0f);
            mainAudioMixer.SetFloat("MusicVolume", 0f);
            mainAudioMixer.SetFloat("SFXVolume", 0f);
            // Adicione mais linhas conforme necess�rio para outros grupos de �udio
        }
    }
}
