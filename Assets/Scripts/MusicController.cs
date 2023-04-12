using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider volumeSlider;

    void Start()
    {
        // Set the initial volume to the value of the slider
        backgroundMusic.volume = volumeSlider.value;

        // Add a listener to the slider so that we can update the volume as it changes
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeSliderChange(); });
    }

    void OnVolumeSliderChange()
    {
        // Update the volume of the background music when the slider value changes
        backgroundMusic.volume = volumeSlider.value;
    }
}

