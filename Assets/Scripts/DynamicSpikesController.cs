using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSpikesController : MonoBehaviour
{

    public SpriteRenderer spikeRenderer;
    public BoxCollider2D spikeCollider;
    [SerializeField] private AudioSource showSpikesSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShowSpikes());
        }
    }

    IEnumerator ShowSpikes()
    {
        yield return new WaitForSeconds(0.4f);
        showSpikesSound.Play();
        spikeRenderer.enabled = true;
        spikeCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        HideSpikes();
    }

    private void HideSpikes()
    {
        spikeRenderer.enabled = false;
        spikeCollider.enabled = false;
    }
}
