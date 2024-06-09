using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{

    GameObject playerObject;

    MainPlayer playerScript;
    //BulletPoint bulletReticle;

    public GameObject particles;

    Rigidbody rb;

    //private GenericPlaySound soundPlay;

    //public ParticleSystem particles;
    public MeshRenderer mesh;

    public float forceMultiplier;
    public float explosionForce;
    public float speed;
    public float fireRateToIncrease;

    public float coinMagnetSpeed;

    public float maxDistanceToPlayer;

    public float timeUntilMagnetStart;

    bool distanceTriggered = false;
    public bool particOnce = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //playerObject = GameObject.FindGameObjectWithTag("Player");

        playerScript = FindObjectOfType<MainPlayer>();
        //bulletReticle = FindObjectOfType<BulletPoint>();

        rb.AddForce(transform.forward * explosionForce, ForceMode.Impulse);

        //soundPlay = GetComponentInParent<GenericPlaySound>();
        
    }

    void Update()
    {

        timeUntilMagnetStart -= Time.deltaTime;

        if(!playerObject)
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
        }

        if(transform.position.y < 0.52)
        {
            transform.position += new Vector3(0, 0.1f, 0);
        }

        if(transform.position.y > 0.52)
        {
            transform.position += new Vector3(0, -0.1f, 0);
        }

        if(playerObject != null && timeUntilMagnetStart <= 0f)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

            Vector3 directionToPlayer = transform.position - playerObject.transform.position;
            //directionToPlayer = directionToPlayer.normalized * forceMultiplier;

            if (distanceToPlayer <= maxDistanceToPlayer)
            {
                distanceTriggered = true;
            }

            if (distanceTriggered == true)
            {
                speed += coinMagnetSpeed;
                transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(playerObject != null)
        {
            if (other.gameObject.CompareTag("Player") && particOnce)
            {

                //soundPlay.canPlaySound = true;

                //var em = particles.emission;

                //em.enabled = true;

                //transform.parent.position = transform.position;

                //particles.Play();

                //particOnce = false;

                //playerScript.AddCoins(1);
                //bulletReticle.IncreaseFireRate(fireRateToIncrease);

                Instantiate(particles, transform.position, Quaternion.identity);

                Destroy(mesh);
                Destroy(gameObject);

            }
        }
        
    }

}
