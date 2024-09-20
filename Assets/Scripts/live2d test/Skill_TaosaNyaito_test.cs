using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_TaosaNyaito_test : MonoBehaviour
{
    //変数宣言
    //敵のタグ用変数
    private const string _enemyTag = "enemy";

    //敵の体力
    [SerializeField] private int _enemyHP = 3;
    //エスケープパート用
    [SerializeField] private int _escapeEnemyHP = 1;

    //ボックスコライダーを取得する
    [SerializeField] private BoxCollider2D _boxCollider2D;

    //剣を回転させる親オブジェクトを取得（本来はアニメーションで剣を振る
    [SerializeField] private Transform _parentTransform;

    //剣のオブジェクト
    [SerializeField] private GameObject _sword;


    private SkillManager_test _skillManager;
    private InputSystemScript _inputSystemScript;
    
    //もしエスケープパートなら１撃で敵を殺す
    // Start is called before the first frame update
    void Start()
    {
        _inputSystemScript = new InputSystemScript();
        _inputSystemScript.Enable();
     
        _skillManager = GetComponent<SkillManager_test>();
    }

    // Update is called once per frame
    void Update()
    {
        //R1＋丸で倒さにゃいと発動

        if (_skillManager.activeSkill == 2)
        {
            //剣の当たり判定を復活させる
            _sword.gameObject.SetActive(true);
            _boxCollider2D.enabled = true;
            _parentTransform.localRotation = Quaternion.identity;
        }
        //三角で待機モードに戻る
        else
        {
            _sword.gameObject.SetActive(false);
            _boxCollider2D.enabled = false;
            _parentTransform.localRotation = Quaternion.Euler(0, 0, 0.01f);
        }
        //Shift＋→で発動
        //敵に武器があったたら敵を消す
        //敵のダメージ計算
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("押したよ");
            
            
            //アニメーション切り替え
            //_animator.SetBool("Taosanyaito", true);
        }
        
        /*アニメーションがうまくいかない
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //_animator.SetBool("Taosanyaito",false);
        }
        */
        
    }
}
