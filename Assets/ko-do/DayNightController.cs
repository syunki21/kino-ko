using UnityEngine;
using UnityEngine.Rendering;

public class DayNightController : MonoBehaviour
{
    [Header("QÆ")]
    public Light sunLight;
    public DayTimer dayTimer;

    [Header("–¾‚é‚³")]
    public float dayIntensity = 1.2f;
    public float nightIntensity = 0.05f;

    [Header("ŠÂ‹«Œõ")]
    public Color dayAmbient = new Color(0.6f, 0.6f, 0.6f);
    public Color nightAmbient = new Color(0.02f, 0.02f, 0.02f);

    void Update()
    {
        float t = dayTimer.NormalizedTime;

        sunLight.intensity =
            Mathf.Lerp(dayIntensity, nightIntensity, t);

        RenderSettings.ambientLight =
            Color.Lerp(dayAmbient, nightAmbient, t);
    }
}
