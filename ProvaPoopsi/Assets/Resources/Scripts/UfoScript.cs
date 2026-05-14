using UnityEngine;

public class PlatformTilt : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform center;

    public float tiltAmount = 10f;
    public float smoothTime = 5f;
    public float moveForce = 10f;
    public float minTilt = 1f;
    public float maxTiltAngle = 30f; // Maximum rotation limit in degrees

    private Rigidbody2D rb;
    private float targetAngle = 0f;
    private float currentAngle = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        float distanceP1 = player1.position.x - center.position.x;
        float distanceP2 = player2.position.x - center.position.x;
        float distance = distanceP1 + distanceP2;

        // Calculate target angle based on weight distribution
        targetAngle -= distance * tiltAmount * Time.deltaTime;

        // Clamp the target angle to the max limit on both sides
        targetAngle = Mathf.Clamp(targetAngle, -maxTiltAngle, maxTiltAngle);

        // Smoothly interpolate toward the target angle
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, smoothTime * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }

void FixedUpdate()
{
    float tilt = currentAngle;
    float tiltFactor = Mathf.Abs(tilt) / maxTiltAngle; // 0.0 (flat) to 1.0 (max tilt)
    Vector2 move;

    if (tilt > minTilt)
    {
        move = -Vector2.right * moveForce * tiltFactor * Time.fixedDeltaTime;
    }
    else if (tilt < -minTilt)
    {
        move = Vector2.right * moveForce * tiltFactor * Time.fixedDeltaTime;
    }
    else
    {
        move = Vector2.zero;
    }

    transform.Translate(move, Space.World);
}
}