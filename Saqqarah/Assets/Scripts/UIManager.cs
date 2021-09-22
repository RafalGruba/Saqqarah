using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool uiIsActive = false;
    int currentSceneIndex;
    [SerializeField] private GameObject panelUI;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiIsActive)
            {
                DeactivateUI();
            }
            else
            {
                ActivateUI();
            }
        }

    }

    public void DeactivateUI()
    {
        panelUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        uiIsActive = false;
        Time.timeScale = 1f;
    }

    public void ActivateUI()
    {
        panelUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        uiIsActive = true;
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
