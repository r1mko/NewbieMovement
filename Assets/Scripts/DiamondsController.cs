using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondsController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject diamondParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.diamoindsSound.Play();
            GameObject collectParticle = Instantiate(diamondParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collectParticle, 0.75f);
            gameManager.diamondsCount--;
        }
    }
}
