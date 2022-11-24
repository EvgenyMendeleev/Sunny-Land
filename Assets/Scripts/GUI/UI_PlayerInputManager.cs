using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObserver;
using UnityEngine.SceneManagement;

[AddComponentMenu("GUI/UI Player Input Manager")]
public class UI_PlayerInputManager : MonoBehaviour
{
    void Start()
    {
        PlayerInput.menuObserver += MenuInput;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        else if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MenuInput(GameEvents gameEvent)
    {
        /*switch (gameEvent)
        {
            case GameEvents.STOP_GAME:
                Application.Quit();
                break;
            case GameEvents.RESTART_LEVEL:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }*/
    }
}
