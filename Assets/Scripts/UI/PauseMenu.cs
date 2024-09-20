using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;

    [SerializeField] private GameObject resumeMenuFirst;
    [SerializeField] private PlayerBehaviour playerBehaviour;
    [SerializeField] private SkillManager skillManager;
    
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        var controller = Gamepad.current;
        if (controller == null)
        {
            Debug.Log("No gamepad connected");
            return;
        }
        if (controller.startButton.wasPressedThisFrame)
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void Resume()
    {
        playerBehaviour.enabled = true;
        skillManager.enabled = true;
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    
    void Pause()
    {
        playerBehaviour.enabled = false;
        skillManager.enabled = false;
        
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(resumeMenuFirst);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        //SceneManager.LoadScene("TitleScene");
    }
    
    public void LoadStageSelection()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        //SceneManager.LoadScene("StageSelection");
    }
}
