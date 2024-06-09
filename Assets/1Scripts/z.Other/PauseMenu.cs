using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameScript gScript;

    public static bool isPaused = false;

    public bool isSettingsMenu = false;

    bool gameScriptFound = false;

    public GameObject pauseMenu;

    public AudioMixer mixer;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {

        if (!gScript && !gameScriptFound)
        {
            gScript = FindObjectOfType<GameScript>();

            if(gScript)
            {
                gameScriptFound = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isSettingsMenu)
        {
            if(isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        gScript.isMainMenuActive = true;
        gScript.hasGameStarted = false;
        gScript.arePrefabsInstantiated = false;

        gScript.toDestroyPlayer = true;
        gScript.toDestroyNpc = true;

        SceneManager.LoadScene(0);
    }



    public void SettingsMenuOn()
    {
        isSettingsMenu = true;
    }

    public void SettingsMenuOff()
    {
        isSettingsMenu = false;
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }
}
