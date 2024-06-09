using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Sword : MonoBehaviour
{

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip swordWhoosh1;
    [SerializeField] AudioClip swordWhoosh2;

    [SerializeField] ParticleSystem particles;
    public float particleTime = 0.10f;
    public bool particlesActive = false;

    public GameObject particles1;

    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    public float swordDamage;

    public float timeUntilMelee = 0f;

    private void Start()
    {
        particlesActive = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {

        int soundToPlay = Random.Range(1, 3);

        timeUntilMelee -= Time.deltaTime;

        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if(soundToPlay == 1)
                {
                    source.clip = swordWhoosh1;
                    source.pitch = Random.Range(0.8f, 1f);
                    source.Play();
                }

                if(soundToPlay > 1)
                {
                    source.pitch = Random.Range(0.8f, 1f);
                    source.clip = swordWhoosh2;
                    source.Play();
                }

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
            other.gameObject.GetComponent<Enemy>().currentHealth -= swordDamage;
        }
    }

}
