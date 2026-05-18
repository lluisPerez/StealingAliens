using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Player movement speed 
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 playerMovement; // Store player movement input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        float moveX = Keyboard.current.dKey.isPressed ? 1 : (Keyboard.current.aKey.isPressed ? -1 : 0); // Get horizontal input
        playerMovement = new Vector2(moveX, 0f).normalized; // Create movement vector and normalize it 
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerMovement.x * speed, 0); // Move the player based on input and speed
    }
}
