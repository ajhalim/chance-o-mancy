using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"You survived for: {ScoreKeeper.Instance.GetScore().ToString()} seconds\n" +
        $"Best: {ScoreKeeper.Instance.GetHighscore().ToString()} seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
