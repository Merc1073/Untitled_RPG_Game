using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveExit : MonoBehaviour
{
    GameScript gScript;

    public GameObject villageSpawn;
    public Vector3 cameraOffset;
    private Collider playerCollider;

    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCollider = other;
            StartCoroutine(DisableTrail());
            StartCoroutine(ChangeArea());
        }
    }

    IEnumerator DisableTrail()
    {
        yield return new WaitForSeconds(gScript.fadeTime);

        playerCollider.gameObject.GetComponent<TrailRenderer>().time = 0f;

        yield return new WaitForSeconds(0.01f);

        playerCollider.gameObject.GetComponent<TrailRenderer>().time = 0.5f;
    }

    IEnumerator ChangeArea()
    {
        gScript.gs_useNormalFadeAnim = true;
        gScript.isPlayerChangingScenes = true;
        gScript.canPlayerControl = false;

        yield return new WaitForSeconds(gScript.fadeTime);

        playerCollider.gameObject.transform.position = villageSpawn.transform.position;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = playerCollider.gameObject.transform.position + cameraOffset;

        gScript.gs_useNormalFadeAnim = false;
        gScript.isPlayerChangingScenes = false;
        gScript.canPlayerControl = true;

    }

}
