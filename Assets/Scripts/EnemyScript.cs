using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float attackRange = 60f;
    private GameObject player;
    private GameObject gameManager;
    float dist;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        gameManager = GameObject.FindGameObjectsWithTag("GameController")[0]; //if only one controller exists
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.SendMessage("NextLevel");
        }
    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < attackRange)
        {
            float step = movementSpeed * Time.deltaTime;
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
