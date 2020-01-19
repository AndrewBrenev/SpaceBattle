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
       
    }
}
