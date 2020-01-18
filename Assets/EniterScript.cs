using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EniterScript : MonoBehaviour
{
    public GameObject initializedObject;
    public float minDelay, maxDelay;

    private float nextAsteroidLaunch;

    // Update is called once per frame
    void Update()
    {
        if(!GameControllerScript.getInstanse().getIsGameStarted())
        {
            return;
        }
        if (Time.time > nextAsteroidLaunch)
        {
            nextAsteroidLaunch = Time.time + Random.Range(minDelay, maxDelay);

            float xSize = transform.localScale.x;
            float xPosition = Random.Range(-xSize / 2, xSize / 2);
            float zPosition = transform.position.z;

            Instantiate(initializedObject, new Vector3(xPosition, 0, zPosition), Quaternion.identity);

        }
    }
}
