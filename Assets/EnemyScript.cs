using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject LaserShot;
    public GameObject LaserGun;
    public GameObject playerExplosion;


    public float speed;
    
    public float shotDelay;
    private float nextShotLaunch;
    private int shotsToKill = 2;

   

    // Start is called before the first frame update
    void Start()
    {
         GetComponent<Rigidbody>().velocity =  Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.getInstanse().getIsGameStarted())
        {
            return;
        }

        if (Time.time > nextShotLaunch)
        {
            Instantiate(LaserShot, LaserGun.transform.position, Quaternion.identity);
            nextShotLaunch = Time.time + shotDelay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "GameBoundary" && GameControllerScript.getInstanse().getIsGameStarted())
        {
            if (shotsToKill == 1)
            {
                if (other.tag == "PlayerShot")
                {
                    GameControllerScript.getInstanse().increaseScore(10);
                    GameControllerScript.getInstanse().increaseEnemiesKilledCount();
                }
                shotsToKill--;
                Instantiate(playerExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                if (other.tag == "PlayerShot")
                {
                    Destroy(other.gameObject);
                    shotsToKill--;
                }
                if (other.tag == "Player" || other.tag == "Asteroid")
                {
                    Instantiate(playerExplosion, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    shotsToKill--;
                }
            }

        }
    }
}
