using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillManager_test : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<GameObject> skills;
    
    [HideInInspector] public int activeSkill;
    
    private bool _isExpanded;
    private bool _isSelected;
    
    private PlayerBehaviour_test _playerBehaviour;
    
    private readonly List<Canvas> _canvasList = new List<Canvas>();
    
    private static readonly int Collapse = Animator.StringToHash("T_Collapse");
    private static readonly int Expand = Animator.StringToHash("T_Expand");

    private void Awake()
    {
        foreach (var s in skills)
        {
            _canvasList.Add(s.GetComponent<Canvas>());
        }

        _playerBehaviour = GetComponent<PlayerBehaviour_test>();
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

        if (gamepad.rightShoulder.isPressed && !_isSelected && !_playerBehaviour.isEscape)
        {
            skills[4].GetComponent<Image>().enabled = false;
            if (!_isExpanded)
            {
                animator.SetTrigger(Expand);
                _isExpanded = true;
            }

            if (gamepad.triangleButton.wasPressedThisFrame)
            {
                _canvasList[0].sortingOrder = 100;
                _canvasList[1].sortingOrder = 99;
                _canvasList[2].sortingOrder = 99;
                _canvasList[3].sortingOrder = 99;
                _canvasList[4].sortingOrder = 99;
                _isSelected = true;
                activeSkill = 1;
            }

            if (gamepad.circleButton.wasPressedThisFrame)
            {
                _canvasList[0].sortingOrder = 99;
                _canvasList[1].sortingOrder = 100;
                _canvasList[2].sortingOrder = 99;
                _canvasList[3].sortingOrder = 99;
                _canvasList[4].sortingOrder = 99;
                _isSelected = true;
                activeSkill = 2;
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
        }
        
        if (!gamepad.rightShoulder.isPressed)
        {
            _isSelected = false;
        }
    }
}
