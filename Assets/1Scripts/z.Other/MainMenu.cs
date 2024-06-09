using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameScript gScript;

    public AudioMixer audioMixer;


    private void Update()
    {
        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }
    }


    public void PlayGame()
    {
        gScript.isPlayerChangingScenes = true;
        gScript.isMainMenuActive = false;

        gScript.toDestroyPlayer = false;
        gScript.toDestroyNpc = false;

        StartCoroutine(StartingGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    IEnumerator StartingGame()
    {
        yield return new WaitForSeconds(gScript.fadeTime);

        SceneManager.LoadScene(1);
    }


    ////--IN-GAME MENU STUFF

    //public void PauseGame()
    //{

    //}

    //public void ReturnMainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}
}
