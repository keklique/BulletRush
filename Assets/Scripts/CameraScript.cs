using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private Vector3 playerPosition;
    private Vector3 cameraPosition;

    void Start()
    {
        Vector3 playerPosition = player.transform.position;
        cameraPosition = transform.position;
    }

    void LateUpdate()
    {
        playerPosition = player.transform.position;
        cameraPosition.x = playerPosition.x;
        cameraPosition.z = playerPosition.z - 10f;
        transform.position = cameraPosition;
    }
}
