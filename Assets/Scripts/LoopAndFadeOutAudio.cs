using UnityEngine;
using System.Collections;

public class LoopAndFadeOutAudio : MonoBehaviour
{
    public AudioClip audioClip;
    public float initialVolume = 1.0f;
    public float fadeOutDuration = 2.0f;

    private AudioSource audioSource;

    void Start()
    {
        // Get the audio source component attached to this game object
        audioSource = GetComponent<AudioSource>();

        // Set the audio clip and volume properties
        audioSource.clip = audioClip;
        audioSource.volume = initialVolume;

        // Enable looping
        audioSource.loop = true;

        // Start playing the audio clip
        audioSource.Play();

        // Start the coroutine to fade out the audio clip
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        // Wait for 2 minutes before starting to fade out the audio clip
        yield return new WaitForSeconds(120);

        // Calculate the amount of volume to decrease per second
        float volumeDecreaseRate = initialVolume / fadeOutDuration;

        // Gradually decrease the volume of the audio clip over the specified duration
        while (audioSource.volume > 0)
        {
            audioSource.volume -= volumeDecreaseRate * Time.deltaTime;
            yield return null;
        }

        // Stop playing the audio clip and reset the volume to its initial value
        audioSource.Stop();
        audioSource.volume = initialVolume;
    }
}

