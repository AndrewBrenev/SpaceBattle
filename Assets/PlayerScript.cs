using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class PlayerScript : MonoBehaviour
{

    public GameObject playerExplosion;

    Rigidbody ship;

    public GameObject LaserGun;
    public GameObject smallLeftGun;
    public GameObject smallRightGun;

    public GameObject LaserShot;
    public GameObject smallLaserShot;


    public float speed;
    public float tilt;

    public float xMin, xMax, zMin,zMax;

    public float shotDelay;
    private float nextShotLaunch;

    private float nextSmllShotLaunch;

    private float timeToDeath;
    private bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.getInstanse().getIsGameStarted())
        {
            return;
        }

        if (death && Time.time > timeToDeath)
        {
            death = false;
            GameControllerScript.getInstanse().stopTheGame();
            
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(xPosition, 0, zPosition);

        if (Input.GetButton("Fire1") && Time.time > nextShotLaunch)
        {
            Instantiate(LaserShot, LaserGun.transform.position, Quaternion.identity);
            nextShotLaunch = Time.time + shotDelay;
        }

        if (Input.GetButton("Fire2") && Time.time > nextSmllShotLaunch)
        {
            Quaternion leftRotation = Quaternion.Euler(0, -30.0f, 0);
            Quaternion rightRotation = Quaternion.Euler(0, 30.0f, 0);

           Instantiate(smallLaserShot, smallLeftGun.transform.position, leftRotation);
           Instantiate(smallLaserShot, smallRightGun.transform.position, rightRotation);
            

            nextSmllShotLaunch = Time.time + (shotDelay * 4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "GameBoundary" && GameControllerScript.getInstanse().getIsGameStarted())
        {
            
            death = true;
            timeToDeath = Time.time + shotDelay;
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            

        }
    }
}

