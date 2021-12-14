using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Notif.play += PlayAgain;
        Notif.back += MainMenu;
        Notif.quit += QuitGame;
        Target.pause += Pause;
        Target.pause += Pause;
        WaveSpawner.Clear += Pause;
    }
    private void OnDisable()
    {
        Notif.play -= PlayAgain;
        Notif.back -= MainMenu;
        Notif.quit -= QuitGame;
        Target.pause -= Pause;
        WaveSpawner.Clear -= Pause;
    }

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Debug.Log("Game has Quit");
        Application.Quit();
    }
    public void PlayAgain()
    {
        Debug.Log("MASUKKKKKKK");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
