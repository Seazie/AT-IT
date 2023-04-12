using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime;
    public Image blackScreen;
    public AudioSource audioSource;

    private float timer;
    private bool isFading;

    void Start()
    {
        // Set the initial values for the timer and the alpha of the black screen
        timer = 0f;
        blackScreen.color = new Color(0f, 0f, 0f, 1f);
        isFading = true;

        // Start playing the audio clip
        audioSource.Play();
    }

    void Update()
    {
        if (isFading)
        {
            // Increase the timer
            timer += Time.deltaTime;

            // Calculate the new alpha value for the black screen
            float alpha = 1f - (timer / fadeInTime);

            // Set the alpha value of the black screen
            blackScreen.color = new Color(0f, 0f, 0f, alpha);

            // Set the volume of the audio clip
            audioSource.volume = 1f - alpha;

            // Check if the fade-in is complete
            if (timer >= fadeInTime)
            {
                isFading = false;
            }
        }
    }
}
