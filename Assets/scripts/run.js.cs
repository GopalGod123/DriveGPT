using UnityEngine;

public class MovingBox : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Base movement speed

    // Timer variables
    private float logTimer = 0f;
    private const float LOG_INTERVAL = 0.5f; // Log every 2 seconds

    void Update()
    {
        // Get input for movement
        float moveX = 0f;
        float moveZ = 0f;

        // Check movement keys
        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
        }

        // Create movement vector
        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;

        // Calculate and apply movement
        Vector3 movement = move * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // Update timer
        logTimer += Time.deltaTime;

        // Log position every 2 seconds
        if (logTimer >= LOG_INTERVAL)
        {
            Debug.Log($"Position: X = {transform.position.x}, Y = {transform.position.y}, Z = {transform.position.z}");
            
            // Reset timer
            logTimer = 0f;
        }
    }
}
