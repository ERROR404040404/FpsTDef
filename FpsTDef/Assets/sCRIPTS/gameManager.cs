using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class gameManager : MonoBehaviour
{
    public bool isPaused = false;
    GameObject pauseMenu;
    PlayerContr player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContr>();
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            pauseMenu.SetActive(false);
        }
    }
        // Update is called once per frame
        void Update()
        {
    
        

    }

    public void loadLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
    public void MainManu()
    {
        loadLevel(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        if (isPaused)
        {
            isPaused = false;

            pauseMenu.SetActive(false);

            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;

            pauseMenu.SetActive(true);

            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
            Resume();
    }
}


