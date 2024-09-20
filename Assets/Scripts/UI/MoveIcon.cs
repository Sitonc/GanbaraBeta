using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour
{
    [SerializeField] GameObject StartPoint;//スタート地点
    [SerializeField] GameObject GoalPoint;//ゴール地点
    [SerializeField] GameObject Player;//プレイヤー

     private float Icon;//進行度メーターのアイコン用の変数
    private float Npos;//今のポジションが何パーセントかを入れる変数

        
    void Update()
    {
        //スタート地点のｘ座標を取得
        float S = StartPoint.transform.position.x;
        //ゴール地点のｘ座標を取得
        float G = GoalPoint.transform.position.x;
        //プレイヤー地点のｘ座標を取得
        float P = Player.transform.position.x;

        float SG = S - G;//スタート地点からゴール地点のｘ軸の距離
        float SP = S - P;//プレイヤー地点からゴール地点のｘ軸の距離

        Npos = ((SP / SG) *100);//現在ステージの何％ぐらいかのチェック
        Icon = Npos * 90;
        transform.position = new Vector3( Icon/10 + 470, 950, 0);
    }
}
