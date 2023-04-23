using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public string audioTag = "BGM";
    public Slider volumeSlider;

    private const float AUDIO_VOLUME_MAX = 1f;

    private void Start()
    {
        // Set the initial value of the slider to the current volume of the audio sources
        volumeSlider.value = AudioListener.volume * 10;

        // Add a listener to the slider so we can adjust the volume of the audio sources when it changes
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void OnVolumeSliderChanged(float newVolume)
    {
        // Find all audio sources with the specified tag
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag(audioTag);
        foreach (GameObject audioObject in audioObjects)
        {
            AudioSource audioSource = audioObject.GetComponent<AudioSource>();
            float mappedValue = MapVolume(newVolume);
            if (audioSource.volume != newVolume)
            {
                audioSource.volume = mappedValue;
            }
        }

    }
    private float MapVolume(float sliderValue)
    {
        return sliderValue / 10f * AUDIO_VOLUME_MAX;
    }
}


