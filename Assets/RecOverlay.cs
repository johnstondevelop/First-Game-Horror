using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecOverlay : MonoBehaviour
{
    public TMP_Text recText;
    public TMP_Text recTimeText;
    public Image recDot;

    private float recordingTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recordingTime += Time.deltaTime;
        int totalSeconds = Mathf.FloorToInt(recordingTime);

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        recTimeText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        if (Time.time % 1 < 0.5f)
        {
            recText.enabled = true;
            recDot.enabled = true;
        }
        else
        {
            recText.enabled = false;
            recDot.enabled = false;
        }
        
    }
}
