using UnityEngine;

public class BoatFloat : MonoBehaviour
{
    [Header("Up / Down")]
    public float moveHeight = 0.02f;
    public float moveSpeed = 1.2f;

    [Header("Forward / Back Tilt")]
    public float tiltAngle = 2f;
    public float tiltSpeed = 1.2f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        float wave = Mathf.Sin(Time.time * moveSpeed);

        
        transform.position =
            startPosition +
            Vector3.up * (wave * moveHeight);

        
        float tilt = wave * tiltAngle;

        transform.rotation =
            startRotation *
            Quaternion.Euler(tilt, 0f, 0f);
    }
}