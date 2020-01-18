using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float speedMovement;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newZposition = Mathf.Repeat(Time.time * speedMovement, 150);
        transform.position = startPosition + Vector3.back * newZposition;
    }
}
