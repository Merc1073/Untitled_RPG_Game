using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameButton : MonoBehaviour
{
    public Button loadButton;
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

        if (saveCooldown <= 0f)
        {
            loadButton.onClick.AddListener(() => gScript.LoadGameFade());

            saveCooldown = originalSaveCooldown;
        }

    }
}
