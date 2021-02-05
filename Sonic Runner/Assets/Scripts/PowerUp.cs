using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ataque"))
        {
            other.GetComponentInParent<PlayerControl>().shield.SetActive(true);
            gameObject.SetActive(false);//desativa monitor
        }
    }
}
