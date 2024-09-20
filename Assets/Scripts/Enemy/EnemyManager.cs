using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    //敵の配置したい座標を取得
    //リストで作りたい
    [SerializeField] private List<Transform> _enemytransforms = new List<Transform>();

    //チーズをとったかどうかの判定をもらうため
    //[SerializeField] private TestPlayerMove _testplayerMove;
    //ここからチーズ持ってるかの判定をもらう
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    

    //敵のプレハブ
    [SerializeField] private GameObject _enemyPrefab;
    
    //チーズをとったかの判定
    //[SerializeField] private CheeseView _cheeseView;

    private List<GameObject> _enemyInstance = new List<GameObject>();
    
//一旦エラー履いてるのでコメントアウト以下を現在のデータで置き換える
    private void Start()
    {
       // _cheeseView.Setup(HitCheese);
    }


    void Update()
    {
        if (_playerBehaviour.hasCheese)
        {
            
            //ここで何回も呼ばれないためにフォルス
            //追記フォルスにするけど問題がある場合はすぐに帰る
            //_playerBehaviour.hasCheese = false;
            
            HitCheese();
            //EnemySpown();

        }
    }
    
    
    private void HitCheese()
    {
        
        foreach (var tform in _enemytransforms)
        {
            
            if (_enemyInstance.Count < 5)
            {
                var gobj = Instantiate(_enemyPrefab);
                gobj.transform.localPosition = tform.localPosition;
                _enemyInstance.Add(gobj);
            }
        }
    }
}
