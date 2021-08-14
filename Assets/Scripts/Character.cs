using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private bool isGameStarted = false;
    private Camera cameraMain;
    private Plane m_Plane;
    private Vector3 hit;

    private void Awake()
    {
        cameraMain = Camera.main;
        m_Plane = new Plane(Vector3.up, Vector3.zero);
        hit = Vector3.up;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) {
            Move(Input.mousePosition);
        }  
    }


    private void Move(Vector2 screenPosition)
    {
        if (isGameStarted == false) isGameStarted = true;

        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        
        Ray ray = cameraMain.ScreenPointToRay(screenCoordinates);
        float ent = 100.0f;
        m_Plane.Raycast(ray, out ent);
        hit = ray.GetPoint(ent);

        float step = movementSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, hit, step);
    }

}
