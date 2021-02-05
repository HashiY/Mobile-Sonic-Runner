using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {// Esse script e para quando cai e morre
            other.GetComponent<PlayerControl>().Morreu();
        }
    }
}
