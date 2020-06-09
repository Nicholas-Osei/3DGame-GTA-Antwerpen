using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class MainMenu : MonoBehaviour {

	public AudioMixer audioMixer;
	public static bool Paused = false;
    public GameObject pauseMenuUi;

	void Start()
	{
		pauseMenuUi.SetActive(false);
	}

	public void Update()
    {
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (Paused)
				{
                    
                    Resume();
                   
                }
				else
				{
                    Cursor.lockState = CursorLockMode.None;
                    Pause();
				}
				Debug.Log("paused");
			}
       
    }

    private void Pause()
    {
		pauseMenuUi.SetActive(true);
		Time.timeScale = 0f;
		Paused = true;
     }

    public void Resume()
    {
		pauseMenuUi.SetActive(false);
		Time.timeScale = 1f;
		Paused = false;

        Aim.LockCroshair();
    }
    public void LoadScene()
    {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu Scene");

	}
    public void PlayGame () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}

    public void SetVolume(float volume)
	{
		audioMixer.SetFloat("Volume", volume);
	}

	public void SetQuality(int qualityvalue)
	{
		QualitySettings.SetQualityLevel(qualityvalue);
	}

	public void SetFullScreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

}
