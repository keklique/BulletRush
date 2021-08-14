using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointScript : MonoBehaviour
{
    [SerializeField]private GameObject gameManager;
    [SerializeField] private GameObject player;

 

    void Update()
    {

        if (Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            gameManager.SendMessage("NextLevel");
        }
    }

}
