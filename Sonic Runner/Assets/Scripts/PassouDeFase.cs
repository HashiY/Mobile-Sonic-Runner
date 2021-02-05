using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassouDeFase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.levelManager.PassouDeFase();
            
        }
    }
}
