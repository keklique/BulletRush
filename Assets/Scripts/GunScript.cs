using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float fireSpeed = 1f;
    [SerializeField] private float fireRange = 1f;
    [SerializeField] private float fireForce = 1f;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject armOfGun;
    private bool allowfire = true;

    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        //Debug.Log(distanceToClosestEnemy);
         
        if (distanceToClosestEnemy < fireRange && allowfire)  StartCoroutine(Fire(closestEnemy)); ;
    }

    IEnumerator Fire(GameObject target)
    {
        allowfire = false;
        Debug.Log("Fire!!!!!");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(dir * fireForce);
        yield return new WaitForSeconds(1f/ fireSpeed);
        allowfire = true;
    }
}
