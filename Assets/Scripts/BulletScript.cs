using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject gameManager;
    

    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameController")[0]; //if only one controller exists
    }
        
        void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        gameManager.SendMessage("ReduceEnemyCount");
    }

    

}
