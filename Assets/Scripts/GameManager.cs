using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform diamonds;
    [SerializeField] private AudioSource playerDeathSound;
    [SerializeField] private GameObject deathParticle;
    public int diamondsCount;
    public AudioSource diamoindsSound;
    void Start()
    {
        diamondsCount = diamonds.transform.childCount;
    }

    private void Update()
    {

        if (diamondsCount == 0)
        {
            levelChanger.FadeToNextLevel();
            SetPlayerActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerDeath();
        }

    }

    public void PlayerDeath()
    {
        if (player.gameObject.activeInHierarchy)
        {
            playerDeathSound.Play();
            GameObject particle = Instantiate(deathParticle, player.transform.position, player.transform.rotation);
            SetPlayerActive(false);
            Destroy(particle, 0.75f);
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetPlayerActive(bool active)
    {
        player.SetActive(active);
    }
}
