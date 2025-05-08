using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HueShiftEffect : MonoBehaviour
{
    public Volume volume; 
    public float hueShiftSpeed = 0.008f;
    public float delayBeforeStart = 30f;
    public float fadeDuration = 5f;

    private ColorAdjustments colorAdjustments;
    private float hue = 0f;
    private float timer = 0f;
    private bool shiftingStarted = false;
    private float fadeTimer = 0f;

    void Start()
    {
        if (volume.profile.TryGet(out colorAdjustments))
        {
            
            colorAdjustments.colorFilter.overrideState = true;
            colorAdjustments.colorFilter.value = Color.white;
        }
    }

    void Update()
    {
        if (colorAdjustments == null) return;

        if (!shiftingStarted)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeStart)
            {
                shiftingStarted = true;
                fadeTimer = 0f;
            }
            else
            {
                return; 
            }
        }

        hue += hueShiftSpeed * Time.deltaTime;
        if (hue > 1f) hue -= 1f;

        fadeTimer += Time.deltaTime;
        float saturation = Mathf.Clamp01(fadeTimer/fadeDuration);

        colorAdjustments.colorFilter.value = Color.HSVToRGB(hue, saturation, 1f);
    }
}

