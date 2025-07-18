using UnityEngine;
using Unity.Netcode;

public class CameraFollow : NetworkBehaviour
{
    public GameObject target;         // The player
    public float smoothSpeed = 5f;   // Smoothing factor
    public Vector3 offset = new Vector3(2f,5);           // Optional offset
    void LateUpdate()
    {
        if (IsHost) { target = GameObject.FindGameObjectWithTag("stoneGolem"); Camera.main.orthographicSize = 1.5f; }
        else if (IsClient) { target = GameObject.FindGameObjectWithTag("windSpirit"); Camera.main.orthographicSize = 1.5f; }
        if (target == null) return;
        Vector3 pos = target.transform.position;
        Vector3 desiredPosition = pos+ offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // keep camera's Z
    }
}
    