using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EniterScript : MonoBehaviour
{
    public GameObject asteroidType1;
    public GameObject asteroidType2;
    public GameObject asteroidType3;

    public GameObject torpedo;

    public GameObject enemyShip;

    public float minDelayAsteroid, maxDelayAsteroid;
    public float minDelayEnemy, maxDelayEnemy;
    public float minDelayTorpedo, maxDelayTorpedo;

    private float nextAsteroidLaunch;
    private float nextEnemyLaunch;
    private float nextTorpedoLaunch;

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.getInstanse().getIsGameStarted())
        {
            return;
        }
        
        if (Time.time > nextAsteroidLaunch)
        {
            nextAsteroidLaunch = Time.time + Random.Range(minDelayAsteroid, maxDelayAsteroid);

            var asteroidId = Random.Range(0, 3);

            switch (asteroidId)
            {
               case 0:
                    generateObject(asteroidType1);
                break;
                case 1:
                    generateObject(asteroidType2);
                    break;
                case 2:
                    generateObject(asteroidType3);
                    break;
            }

        }

        
        if (Time.time > nextEnemyLaunch)
        {
            nextEnemyLaunch = Time.time + Random.Range(minDelayEnemy, maxDelayEnemy);
            generateObject(enemyShip);
        }

        if (Time.time > nextTorpedoLaunch)
        {
            nextTorpedoLaunch = Time.time + Random.Range(minDelayTorpedo, maxDelayTorpedo);
            generateObject(torpedo);
        }
    }

    private GameObject generateObject(GameObject g_object)
    {
        float xSize = transform.localScale.x;
        float xPosition = Random.Range(-xSize / 2, xSize / 2);
        float zPosition = transform.position.z;

        var obj = Instantiate(g_object, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
        return obj;
    }
}
