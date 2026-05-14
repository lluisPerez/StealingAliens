using UnityEngine;

public class Alien2Script : MonoBehaviour
{
    public float thrust = 10f;

    public Transform platform;

    // local limits on platform
    public float leftLimit = -0.446f;
    public float rightLimit = 0.446f;

    void FixedUpdate()
    {
        // Convert player world position into platform local position
        Vector3 localPos = platform.InverseTransformPoint(transform.position);

        float move = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
        }

        // Clamp movement inside platform bounds
        if (move < 0f && localPos.x > leftLimit)
        {
            transform.Translate(-platform.right * thrust * Time.fixedDeltaTime, Space.World);
        }

        if (move > 0f && localPos.x < rightLimit)
        {
            transform.Translate(platform.right * thrust * Time.fixedDeltaTime, Space.World);
        }
    }
}