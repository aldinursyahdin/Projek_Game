using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audiomixer;

    public void SetVolume(float volume)
    {   
        audiomixer.SetFloat("volume", volume);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game Has Started");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Has Quit");
    }
}
