using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AlienScript : MonoBehaviour
{
    public float thrust = 10f;

    public Transform platform;

    // local limits on platform
    public float leftLimit = -0.446f;
    public float rightLimit = 0.446f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Convert player world position into platform local position
        Vector3 localPos = platform.InverseTransformPoint(transform.position);

        float move = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1f;
        }

        // Flip sprite based on movement direction
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = move < 0f;
        }

        // Play animation only when moving
        if (animator != null)
        {
            animator.speed = Mathf.Abs(move) > 0f ? 1f : 0f;
        }

        // Clamp movement inside platform bounds
        if (move < 0f && localPos.x > leftLimit)
        {
            transform.Translate(-platform.right * thrust * Time.fixedDeltaTime, Space.World);
        }
        else if (move > 0f && localPos.x < rightLimit)
        {
            transform.Translate(platform.right * thrust * Time.fixedDeltaTime, Space.World);
        }
    }
}