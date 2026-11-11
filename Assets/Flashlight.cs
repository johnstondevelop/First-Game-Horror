using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public float maxBattery = 100f;
    public float currentBattery;
    public float drainPerSecond = 0.5f;
    public float maxIntensity = 10f;
    public float lowBatteryPoint = 0.25f;
    public  Image batteryFill;
    public TMP_Text batteryText;

    private Light beam;
    private InputAction toggleAction;
    private bool isOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beam = GetComponent<Light>();
        toggleAction = InputSystem.actions.FindAction("Flashlight");
        currentBattery = maxBattery;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleAction.WasPressedThisFrame())
        {
            isOn = !isOn;
        }
        if (isOn)
        {
            currentBattery -= drainPerSecond * Time.deltaTime;
            currentBattery = Mathf.Max(currentBattery, 0f);
        }
        beam.enabled = isOn && currentBattery > 0f;

        float batteryPercent = currentBattery / maxBattery;

        if(batteryPercent >= lowBatteryPoint)
        {
            beam.intensity = maxIntensity;

        }
        else
        {
            beam.intensity = maxIntensity * (batteryPercent / lowBatteryPoint);
        }
        batteryFill.fillAmount = batteryPercent;
        batteryText.text = Mathf.CeilToInt(currentBattery) + "%";

        batteryFill.color = Color.Lerp(Color.red, Color.white, batteryPercent);

    }
    public void AddBattery(float amount)
    {
        currentBattery += amount;
        currentBattery = Mathf.Min(currentBattery, maxBattery);
    }
}
