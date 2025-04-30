using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;

    public void FadeToBlack(float duration)
    {
        StartCoroutine(Fade(0f, 1f, duration));
    }

    public void FadeFromBlack(float duration)
    {
        StartCoroutine(Fade(1f, 0f, duration));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        Color color = fadeImage.color;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
    }
}
