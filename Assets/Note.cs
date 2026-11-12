using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Note : MonoBehaviour
{
    [TextArea(3, 10)]
    public string noteContent;
    public GameObject promptText;
    public GameObject notePanel;
    public TMP_Text noteText;

    private InputAction InteractAction;
    private bool playerInRange = false;
    private bool isReading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractAction = InputSystem.actions.FindAction("Interact");
        promptText.SetActive(false);
        notePanel.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            promptText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            promptText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && InteractAction.WasPressedThisFrame())
        {
            isReading = true;
            notePanel.SetActive(true);
            noteText.text = noteContent;
        }
    }
}
