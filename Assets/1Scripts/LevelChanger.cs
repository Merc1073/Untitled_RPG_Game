using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{

    public Animator anim;

    GameScript gScript;

    private void Update()
    {

        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if (gScript.isPlayerChangingScenes)
        {
            StartCoroutine(LevelFade());
        }
    }

    IEnumerator LevelFade()
    {
        gScript.canPlayerControl = false;

        anim.SetTrigger("FadeOUT");

        yield return new WaitForSeconds(gScript.fadeTime);

        anim.SetTrigger("FadeIN");

        FindObjectOfType<GameScript>().isPlayerChangingScenes = false;
        gScript.canPlayerControl = true;

    }

}
