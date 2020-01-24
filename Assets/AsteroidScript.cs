using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float angularSpeed;
    public float minSpeed,maxSpeed;
    public int explosionPay;
    public int shotsToKill = 1;
    public GameObject asteroidExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * angularSpeed;
        asteroid.velocity = Vector3.back  * Random.Range(minSpeed,maxSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "GameBoundary")
        {
            if (other.tag == "Asteroid" || other.tag == "Torpedo" )
            {
            }
            else
            {
                if (shotsToKill == 1)
                {
                    if (other.tag == "PlayerShot")
                    {
                        GameControllerScript.getInstanse().increaseScore(explosionPay);

                        if (gameObject.tag == "Asteroid")
                            GameControllerScript.getInstanse().increaseAsteroidExplosionCount();
                        else
                            GameControllerScript.getInstanse().increaseTorpedosExplosionCount();

                    }
                    
                    shotsToKill--;
                    Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else
                {
                    if (other.tag == "PlayerShot" || other.tag == "EnemyShot")
                    {
                        Destroy(other.gameObject);
                    }
                    if (other.tag == "Player")
                    {
                        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    shotsToKill--;
                }
            }
        }
    }
}
