using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private Camera unityMainCamera;

    [Header("RoomBoundaries")]
    [SerializeField] private float rightBoundary;
    [SerializeField] private float leftBoundary;
    [SerializeField] private float topBoundary;
    [SerializeField] private float bottomBoundary;

    private void Awake()
    {
        unityMainCamera = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollowPlayer();
    }

    private void CameraFollowPlayer()
    {
        if(player != null)
        {
            transform.position =
            new Vector3(
                Mathf.Clamp(player.transform.position.x, leftBoundary + unityMainCamera.orthographicSize * unityMainCamera.aspect, rightBoundary - unityMainCamera.orthographicSize * unityMainCamera.aspect),
                transform.position.y,
                transform.position.z
            );
        }

    }
}
