using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 0.04f;  // Smoothness of the camera movement
    public Vector3 offset = new Vector3(0f, 0f , -10f);  // Offset position from the player (e.g., camera height or distance)
    public float zoomSpeed = .1f;
    public float zoomOffset;
    public float smoothedZoomOffset;
    public InputAction cameraActions;
    public InputAction cameraZoomOut;
    public Camera cam;

    void OnEnable()
    {
        cameraActions.Enable();
        cameraZoomOut.Enable();
    }
    void OnDisable()
    {
        cameraActions.Disable();
        cameraZoomOut.Disable();
    }

    void LateUpdate()
    {
        offset.x = Mathf.Lerp(offset.x, cameraActions.ReadValue<float>()*10, smoothSpeed);
        transform.position = player.position + offset;  


        zoomOffset = 10 +(15*cameraZoomOut.ReadValue<float>());
        smoothedZoomOffset = cam.orthographicSize+((zoomOffset-cam.orthographicSize)*zoomSpeed);
        cam.orthographicSize = smoothedZoomOffset;

        //transform.position = new Vector3(player.position.x, player.position.y, -10);

    }
}