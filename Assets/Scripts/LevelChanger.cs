using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public ProgressController ProgressController;
    private int levelToLoad;
    [SerializeField] private int numberOfScenes;

    private void Start()
    {
        numberOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        ProgressController.CurrentLevel++;
        PlayerPrefs.SetInt("Level", ProgressController.CurrentLevel);
        if (levelToLoad == numberOfScenes)
        {
            levelToLoad = 0;
            PlayerPrefs.SetInt("Level", 1);
        }
        SceneManager.LoadScene(levelToLoad);
    }
}
