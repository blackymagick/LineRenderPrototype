using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent GoalAction;
    public static GameManager Instance;
    public int currentLevelIndex;
    public int nextLevelIndex;
    public float waitTime = 1.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        nextLevelIndex = currentLevelIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            resetLeve();
        }
    }


    public  void resetLeve()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void nextLevel()
    {
       StartCoroutine(toNextLevel());
    }

    IEnumerator toNextLevel()
    {
        Debug.Log("End Level");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextLevelIndex);
    }


    public string getSceneName()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        return sceneName;
    }

}
