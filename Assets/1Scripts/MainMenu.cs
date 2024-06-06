using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    //public GameObject pauseMenu;


    //private void Start()
    //{
    //    pauseMenu.SetActive(false);
    //}

    //--MAIN MENU STUFF

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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




    ////--IN-GAME MENU STUFF

    //public void PauseGame()
    //{

    //}

    //public void ReturnMainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}
}
