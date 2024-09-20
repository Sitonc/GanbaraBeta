using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Vector2 CameraMaxPos;
    [SerializeField] private Vector2 CameraMinPos;

    [SerializeField] private Vector2 PlayerMaxPos;
    [SerializeField] private Vector2 PlayerMinPos;
    void Update()
    {
        Vector3 CameraPos = Player.transform.position;
        Vector3 PlayerPos = Player.transform.position;
        CameraPos.x =Mathf.Clamp(CameraPos.x, CameraMinPos.x, CameraMaxPos.x);
        CameraPos.y =Mathf.Clamp(CameraPos.y, CameraMinPos.y, CameraMaxPos.y);
        PlayerPos.x = Mathf.Clamp(PlayerPos.x, PlayerMinPos.x, PlayerMaxPos.x);
        PlayerPos.y = Mathf.Clamp(PlayerPos.y, PlayerMinPos.y, PlayerMaxPos.y);
        transform.position = new Vector3(CameraPos.x, CameraPos.y,-10);
        Player.transform.position = new Vector2(PlayerPos.x, PlayerPos.y);
    }
}
