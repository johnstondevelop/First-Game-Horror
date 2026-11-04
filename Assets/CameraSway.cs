using UnityEngine;

public class CameraSway : MonoBehaviour
{
    public float swaySpeed = 0.5f;
    public float swayAmount = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float noiseX = Mathf.PerlinNoise(Time.time * swaySpeed, 0f);
        Debug.Log(noiseX);
        
    }
}
