using UnityEngine;

public class ButterflyIdle : MonoBehaviour
{
    [Header("Flight")]
    public Transform centerPoint;

    public float radius = 0.25f;
    public float orbitSpeed = 15f;

    public float heightOffset = 0.15f;
    public float bobHeight = 0.015f;
    public float bobSpeed = 1.5f;

    [Header("Wings")]
    public Transform wingLeft;
    public Transform wingRight;

    public float flapAngle = 15f;
    public float flapSpeed = 12f;

    private float orbitAngle;

    private Quaternion leftStartRotation;
    private Quaternion rightStartRotation;

    void Start()
    {
        if (wingLeft != null)
            leftStartRotation = wingLeft.localRotation;

        if (wingRight != null)
            rightStartRotation = wingRight.localRotation;
    }

    void Update()
    {
        MoveButterfly();
        AnimateWings();
    }

    void MoveButterfly()
    {
        if (centerPoint == null)
            return;

        orbitAngle += orbitSpeed * Time.deltaTime;

        float rad = orbitAngle * Mathf.Deg2Rad;

        float x = Mathf.Cos(rad) * radius;
        float z = Mathf.Sin(rad) * radius;

        float y =
            heightOffset +
            Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        Vector3 newPosition =
            centerPoint.position +
            new Vector3(x, y, z);

        transform.position = newPosition;

       
        Vector3 moveDirection =
            new Vector3(
                -Mathf.Sin(rad),
                0f,
                Mathf.Cos(rad)
            );

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            transform.rotation =
                Quaternion.LookRotation(moveDirection, Vector3.up);
        }
    }

    void AnimateWings()
    {
        float flap =
            Mathf.Sin(Time.time * flapSpeed) * flapAngle;

        if (wingLeft != null)
        {
            wingLeft.localRotation =
                leftStartRotation *
                Quaternion.Euler(0f, flap, 0f);
        }

        if (wingRight != null)
        {
            wingRight.localRotation =
                rightStartRotation *
                Quaternion.Euler(0f, -flap, 0f);
        }
    }
}