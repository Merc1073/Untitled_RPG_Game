using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Sword : MonoBehaviour
{

    

    

    [SerializeField] ParticleSystem particles;
    public float particleTime = 0.10f;
    public bool particlesActive = false;

    public GameObject particles1;

    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;

    public float timeUntilMelee = 0f;

    private void Start()
    {
        particlesActive = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {

        timeUntilMelee -= Time.deltaTime;

        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                particlesActive = true;
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }

        if (particlesActive)
        {
            particles.Play();
            particleTime -= Time.deltaTime;
        }

        if (particleTime <= 0f && particlesActive)
        {
            particles.Stop();
            particleTime = 0.10f;
            particlesActive = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particles1, transform.position, Quaternion.identity);
        }
    }

}
