using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
    private static bool gamePaused;

    public GameObject menuObject;
    private void Awake()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        menuObject.SetActive(gamePaused);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!gamePaused)
            {
                Paused();
            }
            else
            {
                Continue();
            }
            menuObject.SetActive(gamePaused);
        }
    }
    public void Paused()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        menuObject.SetActive(gamePaused);
    }
    public void Continue() 
    {
        
        gamePaused = false;
        Time.timeScale = 1f;
        menuObject.SetActive(gamePaused);
        Debug.Log(gamePaused);
    }
}
