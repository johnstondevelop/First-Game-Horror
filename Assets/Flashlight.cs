using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    public float maxBattery = 100f;
    public float currentBattery;
    public float drainPerSecond = 0.5f;
    public float maxIntensity = 10f;
    public float lowBatteryPoint = 0.25f;

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
        maxBattery -= Time.deltaTime * drainPerSecond;
        if (isOn && currentBattery > 0f)
        {
            currentBattery -= Time.deltaTime * drainPerSecond;
            beam.intensity = Mathf.Lerp(0f, maxIntensity, currentBattery / maxBattery);
        }
        else
        {
            beam.intensity = 0f;
        }
        
    }
}
