using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") &&
            other.gameObject.GetComponent<PlayerBehaviour>().hasCheese)
        {
            Debug.Log("Finish");
            SceneManager.LoadScene("Result");
        }
    }
}
 