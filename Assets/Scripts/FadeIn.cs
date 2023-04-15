using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public Image blackBackground;
    public float fadeInTime = 7.0f;
    public AudioSource musicSource;
    public float musicFadeInTime = 7.0f;

    void Start()
    {
        // Start with a black background
        Color startColor = Color.black;
        startColor.a = 1.0f;
        blackBackground.color = startColor;

        // Fade in the scene
        StartCoroutine(FadeInScene());

        // Start the music fade-in after a set time
        StartCoroutine(FadeInMusic());
    }

    IEnumerator FadeInScene()
    {
        // Fade in the black background
        float timer = 0.0f;
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeInTime);
            Color newColor = blackBackground.color;
            newColor.a = alpha;
            blackBackground.color = newColor;
            yield return null;
        }

        // Disable the black background
        blackBackground.gameObject.SetActive(false);
    }

    IEnumerator FadeInMusic()
    {
        // Fade in the music
        musicSource.Play();
        float timer = 0.0f;
        while (timer < musicFadeInTime)
        {
            timer += Time.deltaTime;
            float volume = Mathf.Lerp(0.0f, 1.0f, timer / musicFadeInTime);
            musicSource.volume = volume;
            yield return null;
        }
    }
}

