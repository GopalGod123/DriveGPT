using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // Player ya object jisko follow karna hai
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Camera ki position ka fark
    public float smoothSpeed = 0.125f; // Jitna chhota, utna smooth (0.1 best hai)

    void LateUpdate()
    {
        if (target == null) return;

        // Target position + offset
        Vector3 desiredPosition = target.position + offset;

        // Smooth movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply position
        transform.position = smoothedPosition;

        // Target ko dekhna chaahta hai toh uncomment karein:
        // transform.LookAt(target);
    }
}
