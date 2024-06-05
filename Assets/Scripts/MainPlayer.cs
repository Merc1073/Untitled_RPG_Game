using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{

    [SerializeField] private float forceMultiplier;

    [SerializeField] private float acceleration;
    //[SerializeField] private float deceleration;


    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //if(moveHorizontal == 1f || moveHorizontal == -1f)
        //{
        //    acceleration += Mathf.Abs(moveHorizontal) * 0.1f * Time.deltaTime;
        //}

        //if (moveVertical == 1f || moveVertical == -1f)
        //{
        //    acceleration += Mathf.Abs(moveVertical) * 0.1f * Time.deltaTime;
        //}

        //if(moveHorizontal != 0f && moveVertical != 0f)
        //{
        //    acceleration += 0.05f * Time.deltaTime;
        //}

        //if(moveHorizontal <= 0f && moveVertical <= 0f)
        //{
        //    acceleration -= 0.2f * Time.deltaTime;
        //}

        //if (acceleration > 5f)
        //{
        //    acceleration = 5f;
        //}

        //if(acceleration < 0f)
        //{
        //    acceleration = 0f;
        //}

        //Debug.Log(acceleration);
        //Debug.Log(moveHorizontal);



        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        rb.AddForce(movement * forceMultiplier * Time.deltaTime);

    }
}
