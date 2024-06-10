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

        if (gScript.gs_useNormalFadeAnim)
        {
            StartCoroutine(LevelFade());
        }

        if(gScript.gs_useFadeOutOnly)
        {
            FadeOutOnly();
        }
        //if(!gScript.isPlayerAlive && gScript.gs_CurrentPlayer)
        //{
        //    StartCoroutine(LevelFade());
        //}

    }

    IEnumerator LevelFade()
    {
        gScript.canPlayerControl = false;

        anim.SetTrigger("FadeOUT");

        yield return new WaitForSeconds(gScript.fadeTime);

        anim.SetTrigger("FadeIN");

        gScript.isPlayerChangingScenes = false;
        gScript.canPlayerControl = true;
    }

    public void FadeOutOnly()
    {
        anim.SetTrigger("FadeIN");

        gScript.isPlayerChangingScenes = false;
        gScript.canPlayerControl = true;
    }

}
