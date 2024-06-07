using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{

    

    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private float forceMultiplier;

    [SerializeField] private GameObject reticle;

    [SerializeField] private GameObject healthBar;

    [SerializeField] private GameObject mainPlayer;

    private float rotateVelocity;
    private float rotateSpeedMovement;

    public bool swordActive = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        rb.AddForce(movement * forceMultiplier * Time.deltaTime);

        if (mainPlayer.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<Sword>())
        {
            if (mainPlayer.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<Sword>().timeUntilMelee <= 0)
            {
                Quaternion rotationToLookAt = Quaternion.LookRotation(reticle.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));
                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Enemy"))
    //    {
    //        healthBar.GetComponent<PlayerHealthBar>().health -= Random.Range(5f, 10f);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            healthBar.GetComponent<PlayerHealthBar>().health -= Random.Range(5f, 10f);
        }
    }

}
