using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Outro");
        }

    }
}
