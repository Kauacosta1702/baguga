using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // arraste o personagem aqui
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // use (0, 0, -10) para 2D

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
