using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float angularSpeed;
    public float minSpeed,maxSpeed; 

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

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
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            }
            else
            {
                GameControllerScript.getInstanse().increaseScore(2);
            }

          

            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);

           
        }
    }
}
