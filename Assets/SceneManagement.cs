using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class SceneManagement : MonoBehaviour {

    public GameObject settingsUI;
    public GameObject PauseMenuUI;
    int i;
    bool settingsUIOpened = false;



    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsUIOpened == false)
            {
                OpenSettingsUI();
            }
            /*
            if (settingsUIOpened == true)
            {
                CloseSettingsUI();
            }*/
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            OpenPauseMenuUI();
        }
        else
        {
            ClosePauseMenuUI();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OpenSettingsUI()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        settingsUI.SetActive(true);
        settingsUIOpened = true;
    }

    public void CloseSettingsUI()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        settingsUI.SetActive(false);
        settingsUIOpened = false;
    }

    void OpenPauseMenuUI()
    {
        PauseMenuUI.SetActive(true);
    }

    void ClosePauseMenuUI()
    {
        PauseMenuUI.SetActive(false);
    }
}
