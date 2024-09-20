using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private bool toMenu;
    [SerializeField] private bool toGame;
    
    private InputSystemScript _inputSystemScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputSystemScript = new InputSystemScript();
        _inputSystemScript.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var controller = Gamepad.current;
        if (controller == null)
        {
            Debug.Log("No gamepad connected");
            return;
        }

        if (controller.circleButton.wasPressedThisFrame)
        {
            if (toMenu)
                SceneManager.LoadScene("TitleScene");
                    
            if (toGame)
                SceneManager.LoadScene("Stage_Ver3");
        }
    }
    
}
