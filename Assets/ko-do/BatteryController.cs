using UnityEngine;
using UnityEngine.UI;
using System;

public class BatteryController : MonoBehaviour
{
    [Header("“d’rÝ’è")]
    public float maxBattery = 100f;
    public float drainPerSecond = 5f;

    [Header("UI")]
    public Slider batterySlider;

    [Header("ŽQÆ")]
    public DayTimer dayTimer;

    float currentBattery;

    public bool IsEmpty => currentBattery <= 0f;

    public event Action OnBatteryEmpty;

    void Start()
    {
        currentBattery = maxBattery;
        UpdateUI();
    }

    void Update()
    {
        if (dayTimer.CurrentPhase == DayPhase.Night && currentBattery > 0f)
        {
            currentBattery -= drainPerSecond * Time.deltaTime;
            currentBattery = Mathf.Max(currentBattery, 0f);
            UpdateUI();

            if (currentBattery <= 0f)
            {
                OnBatteryEmpty?.Invoke();
            }
        }
    }

    void UpdateUI()
    {
        batterySlider.value = currentBattery / maxBattery;
    }
}
