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
                    Cursor.lockState = CursorLockMode.None;
                    Resume();
				}
				else
				{
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
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUi.SetActive(false);
		Time.timeScale = 1f;
		Paused = false;
	}
    public void LoadScene()
    {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu Scene");

	}
    public void PlayGame () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.Locked;
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
