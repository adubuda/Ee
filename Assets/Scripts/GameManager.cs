using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float requiredScore;
    GameObject spike;
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        spike = GameObject.FindWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        requiredScore = spike.GetComponent<spikeMove>().score;
        if (requiredScore > 1000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
