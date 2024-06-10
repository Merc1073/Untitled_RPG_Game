using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameButton : MonoBehaviour
{
    public Button saveButton;
    GameScript gScript;

    public float originalSaveCooldown;
    public float saveCooldown;

    private void Update()
    {

        saveCooldown -= Time.deltaTime;

        if (!gScript)
        {
            gScript = FindObjectOfType<GameScript>();
        }

        if(saveCooldown <= 0f)
        {
            //saveButton.onClick.AddListener(() => gScript.SavePlayer());
            saveButton.onClick.AddListener(() => gScript.SaveGameData());
            
            saveCooldown = originalSaveCooldown;
        }
        
    }

}
