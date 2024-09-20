using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<GameObject> skills;
    
    [HideInInspector] public int activeSkill;
    
    private bool _isExpanded;
    private bool _isSelected;
    
    private Animator _playerAnimator;
    
    private PlayerBehaviour _playerBehaviour;
    
    private readonly List<Canvas> _canvasList = new List<Canvas>();
    
    private static readonly int Collapse = Animator.StringToHash("T_Collapse");
    private static readonly int Expand = Animator.StringToHash("T_Expand");

    private void Awake()
    {
        foreach (var s in skills)
        {
            _canvasList.Add(s.GetComponent<Canvas>());
        }

        _playerBehaviour = GetComponent<PlayerBehaviour>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("No gamepad connected");
            return;
        }

        if (activeSkill == 0)
        {
            skills[4].GetComponent<Image>().enabled = true;
        }

        if (gamepad.rightShoulder.isPressed && !_isSelected)
        {
            skills[4].GetComponent<Image>().enabled = false;
            if (!_isExpanded)
            {
                animator.SetTrigger(Expand);
                _isExpanded = true;
            }

            if (gamepad.triangleButton.wasPressedThisFrame && !_playerBehaviour.isEscape)
            {
                _canvasList[0].sortingOrder = 100;
                _canvasList[1].sortingOrder = 99;
                _canvasList[2].sortingOrder = 99;
                _canvasList[3].sortingOrder = 99;
                _canvasList[4].sortingOrder = 99;
                _isSelected = true;
                activeSkill = 1;
                _playerAnimator.SetTrigger("GanbaraNyaito");
            }

            if (gamepad.circleButton.wasPressedThisFrame && !_playerBehaviour.isEscape)
            {
                _canvasList[0].sortingOrder = 99;
                _canvasList[1].sortingOrder = 100;
                _canvasList[2].sortingOrder = 99;
                _canvasList[3].sortingOrder = 99;
                _canvasList[4].sortingOrder = 99;
                _isSelected = true;
                activeSkill = 2;
                _playerAnimator.SetTrigger("TaosaNyaito");
            }
            
            if (gamepad.crossButton.wasPressedThisFrame)
            {
                _canvasList[0].sortingOrder = 99;
                _canvasList[1].sortingOrder = 99;
                _canvasList[2].sortingOrder = 100;
                _canvasList[3].sortingOrder = 99;
                _canvasList[4].sortingOrder = 99;
                _isSelected = true;
                activeSkill = 3;
                _playerAnimator.SetTrigger(!_playerBehaviour.isEscape ? "NakaNyaito" : "NigeNaka");
            }

            if (gamepad.squareButton.wasPressedThisFrame)
            {
                _canvasList[0].sortingOrder = 99;
                _canvasList[1].sortingOrder = 99;
                _canvasList[2].sortingOrder = 99;
                _canvasList[3].sortingOrder = 100;
                _canvasList[4].sortingOrder = 99;
                _isSelected = true;
                activeSkill = 4;
                if (_playerBehaviour.hasCheese)
                    _playerAnimator.SetTrigger("NakaNige");
            }
        }
        else
        {
            if (_isExpanded)
            {
                animator.SetTrigger(Collapse);
                _isExpanded = false;
            }
        }

        if (gamepad.triangleButton.wasPressedThisFrame && !_isSelected && !_playerBehaviour.isEscape)
        {
            _playerBehaviour.ResetSkill();
            activeSkill = 0;
            _canvasList[0].sortingOrder = 99;
            _canvasList[1].sortingOrder = 99;
            _canvasList[2].sortingOrder = 99;
            _canvasList[3].sortingOrder = 99;
            _canvasList[4].sortingOrder = 100;
            _playerAnimator.SetTrigger("NormalNyaito");
        }
        
        if (!gamepad.rightShoulder.isPressed)
        {
            _isSelected = false;
        }
    }
}
