using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMovement : MonoBehaviour
{
    public bird Bird;
    public float moveSpeed = 5;
    public float offScreen = -12;
    void Start()
    {
        Bird = GameObject.FindGameObjectWithTag("bird").GetComponent<bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.birdIsAlive)
        {
            if (transform.position.x < offScreen)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
            }
        }
    }
}
