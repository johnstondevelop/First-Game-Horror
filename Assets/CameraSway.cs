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
        float noiseY = Mathf.PerlinNoise(Time.time * swaySpeed, 10f); // TODO: Create noiseY the same way, using 10f instead of 0f
        float swayX = (noiseX - 0.5f) * 2f;
        float swayY = (noiseY - 0.5f) * 2f; // TODO: Convert noiseX to a value from -1 to 1
        transform.localRotation = Quaternion.Euler(
            swayX * swayAmount,
            swayY * swayAmount,
            0f
        ); // TODO: Multiply both by swayAmount

        // TODO: Apply them to transform.localRotation
        
    }
}
