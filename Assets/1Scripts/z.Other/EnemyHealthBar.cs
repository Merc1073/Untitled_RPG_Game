using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth;
    public float health;
    [SerializeField] private float lerpSpeed;

    public GameObject enemy;
    public Transform canvasTransform1;


    private void Start()
    {
        health = maxHealth;
    }

    private void LateUpdate()
    {
        canvasTransform1.position = enemy.transform.position + new Vector3(0, 1, -2);
        canvasTransform1.rotation = Quaternion.Euler(90, 0, 0);
    }

    private void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed * Time.deltaTime);
        }
    }

}
