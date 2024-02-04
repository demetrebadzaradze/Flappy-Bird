using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class bird : MonoBehaviour
{
    public AudioSource wingSound;
    public AudioSource hitSound;
    public logics logic;
    public Rigidbody2D rigidbody2D;
    public float rotationAmount = 25f;
    public float rotationSpeed = 5f;
    public float plafStrenght;
    public bool birdIsAlive = true;
    public float offScreen = 5.4f;
    // Start is called before the first frame update
    void Start()
    {
        plafStrenght = 10;
        logic = GameObject.FindGameObjectWithTag("LogicsTag").GetComponent<logics>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            rigidbody2D.velocity = Vector2.up * plafStrenght;
            wingSound.Play();
        }
        if (rigidbody2D.position.y >= offScreen || rigidbody2D.position.y <= -offScreen)
        {
            logic.GameOver();
        }
        
        SetRotationAmount();
        
        Rotate();
    }
    void Rotate()
    {
        quaternion currentRotation = transform.rotation;
        float newRotation = rotationAmount + rotationSpeed * Time.deltaTime;

        quaternion targetRotationQuat = Quaternion.Euler(0f, 0f, newRotation);

        transform.rotation = Quaternion.Slerp(currentRotation, targetRotationQuat, rotationSpeed * Time.deltaTime);
    }
    void SetRotationAmount()
    {
        if (rigidbody2D.velocity.y < -3)
        {
            rotationAmount = -30f;
            rotationSpeed = 50f;
        }
        else if (rigidbody2D.velocity.y > 0)
        {
            rotationAmount = 25f;
            rotationSpeed = 30f;
        }
        else
        {
            rotationAmount = 0f;
            rotationSpeed = 30f;
        }
    }
    public void OnCollisionEnter2D()
    {
        hitSound.Play();
        rigidbody2D.GetComponent<Collider2D>().enabled = false;
        logic.GameOver();
    }
}
