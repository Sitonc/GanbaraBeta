using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour
{
    [SerializeField] GameObject StartPoint;//�X�^�[�g�n�_
    [SerializeField] GameObject GoalPoint;//�S�[���n�_
    [SerializeField] GameObject Player;//�v���C���[

     private float Icon;//�i�s�x���[�^�[�̃A�C�R���p�̕ϐ�
    private float Npos;//���̃|�W�V���������p�[�Z���g��������ϐ�

        
    void Update()
    {
        //�X�^�[�g�n�_�̂����W���擾
        float S = StartPoint.transform.position.x;
        //�S�[���n�_�̂����W���擾
        float G = GoalPoint.transform.position.x;
        //�v���C���[�n�_�̂����W���擾
        float P = Player.transform.position.x;

        float SG = S - G;//�X�^�[�g�n�_����S�[���n�_�̂����̋���
        float SP = S - P;//�v���C���[�n�_����S�[���n�_�̂����̋���

        Npos = ((SP / SG) *100);//���݃X�e�[�W�̉������炢���̃`�F�b�N
        Icon = Npos * 90;
        transform.position = new Vector3( Icon/10 + 470, 950, 0);
    }
}
