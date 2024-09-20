using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningManager : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour playerBehaviour;
    
    public GameObject warningUI;
    
    private Image _warningImage;
    private bool _showWarning;

    private float _timer = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        _warningImage = warningUI.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBehaviour.hasCheese && !_showWarning)
        {
            warningUI.SetActive(true);
            _showWarning = true;
            playerBehaviour.isStopped = true;
        }
        
        if (_showWarning)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                warningUI.SetActive(false);
                playerBehaviour.isStopped = false;
                _timer = 2f;
            }
        }
    }
}
