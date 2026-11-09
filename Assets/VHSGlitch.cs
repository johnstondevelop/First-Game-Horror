using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VHSGlitch : MonoBehaviour
{
    public float minTimeBetween = 4f;
    public float maxTimeBetween = 10f;
    public float glitchDuration = 0.15f;
    public float glitchAberration = 0.1f;
    public float glitchDistortion = -0.5f;

    private ChromaticAberration aberration;
    private LensDistortion distortion;
    private float normalAberration;
    private float normalDistortion;
    private float timeUntilGlitch;
    private float glitchTimeLeft = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Volume volume = GetComponent<Volume>();
        volume.profile.TryGet(out aberration);
        volume.profile.TryGet(out distortion);

        normalAberration = aberration.intensity.value;
        normalDistortion = distortion.intensity.value;

        timeUntilGlitch = Random.Range(minTimeBetween, maxTimeBetween);
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilGlitch -= Time.deltaTime;
        if (timeUntilGlitch <= 0f)
        {
            glitchTimeLeft = glitchDuration;
            timeUntilGlitch = Random.Range(minTimeBetween, maxTimeBetween);
        }
        else if (glitchTimeLeft > 0f)
        {
            glitchTimeLeft -= Time.deltaTime;
            aberration.intensity.value = glitchAberration;
            distortion.intensity.value = glitchDistortion;
        }
        else
        {
            aberration.intensity.value = normalAberration;
            distortion.intensity.value = normalDistortion;
        }
    }
}
