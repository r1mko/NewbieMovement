using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.PlayerDeath();
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
