using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
     
    [SerializeField] float steerSpeed = 80f;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float BoostSpeed = 30f;



    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Solid")
        {
            moveSpeed = slowSpeed;
        }
        else if(other.tag == "Boost")
        {
            moveSpeed = BoostSpeed;
        }
    }
}
