using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemies : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour playerBehaviour;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private AudioSource actionBgm;
    [SerializeField] private AudioSource escapeBgm;
    

    // Update is called once per frame
    void Update()
    {
        if (playerBehaviour.hasCheese)
        {
            actionBgm.Stop();
            if (!escapeBgm.isPlaying)
                escapeBgm.Play();
            foreach (var enemy in enemies)
            {
                enemy.SetActive(true);
            }
        }
    }
}
