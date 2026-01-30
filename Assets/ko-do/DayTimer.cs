using UnityEngine;
using System;
public enum DayPhase
{
    Morning,
    Day,
    Night
}

public class DayTimer : MonoBehaviour
{
    [Header("ŽžŠÔÝ’è")]
    public float dayLength = 300f; // 1“ú = 300•b‚È‚Ç

    private float currentTime;

    public float NormalizedTime =>
        Mathf.Clamp01(currentTime / dayLength);

    public DayPhase CurrentPhase { get; private set; }

    public event Action<DayPhase> OnPhaseChanged;

    void Update()
    {
        currentTime += Time.deltaTime;

        UpdatePhase();
    }

    void UpdatePhase()
    {
        DayPhase newPhase;

        float t = NormalizedTime;

        if (t < 0.3f)
            newPhase = DayPhase.Morning;
        else if (t < 0.7f)
            newPhase = DayPhase.Day;
        else
            newPhase = DayPhase.Night;

        if (newPhase != CurrentPhase)
        {
            CurrentPhase = newPhase;
            OnPhaseChanged?.Invoke(CurrentPhase);
        }
    }
}
