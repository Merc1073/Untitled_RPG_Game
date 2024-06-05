using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{

    [SerializeField] ParticleSystem particles;
    public float particleTime = 0.2f;
    public bool particlesActive = false;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject reticle;

    [SerializeField] private float forceMultiplier;

    private float rotateVelocity;
    private float rotateSpeedMovement;

    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;

    float timeUntilMelee = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        particlesActive = false;
    }

    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        rb.AddForce(movement * forceMultiplier * Time.deltaTime);

        


        if(timeUntilMelee <= 0f)
        {

            Quaternion rotationToLookAt = Quaternion.LookRotation(reticle.transform.position - transform.position);
            float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));
            transform.eulerAngles = new Vector3(0, rotationY, 0);

            if (Input.GetMouseButtonDown(0))
            {
                particles.Play();
                particlesActive = true;
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;

                
            }

            //else
            //{
            //    timeUntilMelee -= Time.deltaTime;
            //}
        }

        if(particlesActive)
        {
            particleTime -= Time.deltaTime;
        }

        if (particleTime <= 0f && particlesActive)
        {
            particleTime = 0.2f;
            particlesActive = false;
        }

        //particles.Stop();

        timeUntilMelee -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Enemy hit.");
        }
    }

}
