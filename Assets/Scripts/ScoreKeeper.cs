using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            best = Instance.best;
            Destroy(Instance.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    float startTime;
    float endTime;
    float best;

    private void Start()
    {
        startTime = Time.time;
    }

    public void GameOver()
    {
        endTime = Time.time;
        SceneChanger.ChangeSceneTo("GameOver");
    }

    public int GetScore()
    {
        return (int)(endTime - startTime);
    }
    public int GetHighscore()
    {
        best = Mathf.Max(best, GetScore());
        return (int)(best);
    }
}
