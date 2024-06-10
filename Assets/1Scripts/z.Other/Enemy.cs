using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameScript gScript;

    GameObject player;
    Rigidbody rb;

    public GameObject particles;

    public GameObject expOrb;

    public MeshRenderer mesh;

    public GameObject healthBar;

    //private EnemyPlaySound soundPlay;


    public float maxHealth;
    public float currentHealth;

    public float forceMultiplier;
    public float totalForceMultiplier;

    public int currentExpOrbCounter;
    public int minExpOrbs;
    public int maxExpOrbs;

    public Vector3 expOrbPosition;

    bool playerFound = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {

        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if (!player && !playerFound)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerFound = true;
        }

        healthBar.GetComponent<EnemyHealthBar>().health = currentHealth;
        healthBar.GetComponent<EnemyHealthBar>().maxHealth = maxHealth;

        totalForceMultiplier = forceMultiplier;// + gamescript.globalEnemyForceMultiplier;


        if(player && gScript.isPlayerAlive)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            Vector3 directionToPlayer = transform.position - player.transform.position;
            directionToPlayer = directionToPlayer.normalized * forceMultiplier;// + gamescript.globalEnemyForceMultiplier);

            if (distanceToPlayer < 20f)
            {
                rb.AddForce(-directionToPlayer * Time.deltaTime);
            }
        }

        if (currentHealth <= 0f)
        {

            GameObject clone;
            currentExpOrbCounter = Random.Range(minExpOrbs, maxExpOrbs);

            while (currentExpOrbCounter != 0)
            {

                //coinPosition = new Vector3(Random.Range(0.5f, -0.5f), -2.0f, Random.Range(0.5f, -0.5f));
                clone = Instantiate(expOrb, transform.position + expOrbPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
                currentExpOrbCounter--;
            }

            //gamescript.ReduceEnemy();

            Instantiate(particles, transform.position, Quaternion.identity);
            //soundPlay.canPlaySound = true;

            //var em = particles.emission;

            //em.enabled = true;

            //transform.parent.position = transform.position;

            //particles.Play();

            //particOnce = false;

            if(transform.parent.gameObject.name == "CaveEnemy")
            {
                gScript.caveEnemyCounter--;
            }

            Destroy(mesh);
            Destroy(transform.parent.gameObject);

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (player)
        {
            Vector3 directionToPlayer = transform.position - player.transform.position;
            directionToPlayer = directionToPlayer.normalized * forceMultiplier;

            if (other.gameObject.CompareTag("Sword"))
            {
                rb.AddForce(directionToPlayer * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }


}
