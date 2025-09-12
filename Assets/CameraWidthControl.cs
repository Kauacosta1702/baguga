using UnityEngine;

[ExecuteAlways]
public class CameraWidthControl : MonoBehaviour
{
    public float targetWidth = 16f; // Largura que você quer que a câmera sempre mostre

    void Update()
    {
        Camera cam = GetComponent<Camera>();
        float screenRatio = (float)Screen.width / (float)Screen.height;
        cam.orthographicSize = targetWidth / (2f * screenRatio);
    }
}