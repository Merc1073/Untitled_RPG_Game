using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject player;
    Rigidbody rb;

    public GameObject particles;

    public GameObject expOrb;

    public MeshRenderer mesh;

    //private HealthBar enemyHealthBar;

    //private EnemyPlaySound soundPlay;


    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public float forceMultiplier;
    public float totalForceMultiplier;

    public int currentExpOrbCounter;
    public int minExpOrbs;
    public int maxExpOrbs;

    public Vector3 expOrbPosition;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");

    }


    private void Update()
    {
        totalForceMultiplier = forceMultiplier;// + gamescript.globalEnemyForceMultiplier;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        Vector3 directionToPlayer = transform.position - player.transform.position;
        directionToPlayer = directionToPlayer.normalized * forceMultiplier;// + gamescript.globalEnemyForceMultiplier);


        rb.AddForce(-directionToPlayer * Time.deltaTime);

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
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

            Destroy(mesh);
            Destroy(gameObject);

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
                currentHealth -= 1;

                //if (enemyHealthBar)
                //{
                //    enemyHealthBar.UpdateHealthBar(maxHealth, currentHealth);
                //}

                rb.AddForce(directionToPlayer * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }


}
