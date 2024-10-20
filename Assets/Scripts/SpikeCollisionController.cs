using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeCollisionController : MonoBehaviour
{
    public bool playerIsDead = false;
    [SerializeField] private GameManager gameManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerIsDead)
        {
            playerIsDead = true;
            gameManager.PlayerDeath();
        }
    }
}
