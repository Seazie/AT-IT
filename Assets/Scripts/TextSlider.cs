using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSlider : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;

    private void Start()
    {
        // Update the text with the initial value of the slider
        text.text = slider.value.ToString("0");

        // Add a listener to the slider's value changed event
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float newValue)
    {
        // Update the text object to display the new value of the slider
        text.text = newValue.ToString("0");
    }
}


