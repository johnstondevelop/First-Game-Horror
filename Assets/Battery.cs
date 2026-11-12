using UnityEngine;
using UnityEngine.InputSystem;

public class Battery : MonoBehaviour
{
    public float chargeAmount = 50f;
    public GameObject promptText;

    private InputAction InteractAction;
    private Flashlight flashlight;
    private bool playerInRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractAction = InputSystem.actions.FindAction("Interact");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            flashlight = other.GetComponentInChildren<Flashlight>();
            promptText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            flashlight = null;
            promptText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (playerInRange && InteractAction.WasPressedThisFrame())
        {
            if (flashlight != null)
            {
                flashlight.AddBattery(chargeAmount);
                promptText.SetActive(false);
                Destroy(gameObject);
            }
        } 
        
    }
    
}
