using UnityEngine;

public class CameraSway : MonoBehaviour
{
    public float swaySpeed = 0.5f;
    public float swayAmount = 1.5f;
    public PlayerController player;
    public float sprintSwaySpeed = 2f;
    public float sprintSwayAmount = 3f;
    public float swayBlendSpeed = 3f;


    private float moveBlend = 0f;
    private float noiseTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targetBlend = player.currentSpeed / player.sprintSpeed;
        moveBlend = Mathf.MoveTowards(moveBlend, targetBlend, swayBlendSpeed * Time.deltaTime);
        float currentSwaySpeed = Mathf.Lerp(swaySpeed, sprintSwaySpeed, moveBlend);
float currentSwayAmount = Mathf.Lerp(swayAmount, sprintSwayAmount, moveBlend);
noiseTime += currentSwaySpeed * Time.deltaTime;

        float noiseX = Mathf.PerlinNoise(noiseTime, 0f);
        float noiseY = Mathf.PerlinNoise(noiseTime, 10f);
        float swayX = (noiseX - 0.5f) * 2f;
        float swayY = (noiseY - 0.5f) * 2f; // TODO: Convert noiseX to a value from -1 to 1
        transform.localRotation = Quaternion.Euler(
            swayX * currentSwayAmount,
            swayY * currentSwayAmount,
            0f
        ); // TODO: Multiply both by swayAmount

        // TODO: Apply them to transform.localRotation
        
    }
}
