using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    [Header("éQè∆")]
    public Light flashLight;
    public DayTimer dayTimer;
    public BatteryController battery;
    void Start()
    {
        flashLight.enabled = false;
        dayTimer.OnPhaseChanged += OnPhaseChanged;
        battery.OnBatteryEmpty += TurnOff;
    }

    void OnPhaseChanged(DayPhase phase)
    {
        if (phase == DayPhase.Night)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    void TurnOn()
    {
        flashLight.enabled = true;
    }
    void TurnOff()
    {
        flashLight.enabled = false;
    }

}
