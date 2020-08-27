using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] float scrollValue;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI inGameScoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;

    private Bird bird;

    public bool IsGameOver { get; set; }

    private void Start()
    {

        Time.timeScale = 1;

        bird = FindObjectOfType<Bird>();
    }

    public float ScrollValue
    {
        get
        {
            return -scrollValue;
        }
    }
    private void Update()
    {
        inGameScoreText.SetText( "Score " + bird.Score);
        if (IsGameOver)
        {
            finalScoreText.SetText("Your final score is " + bird.Score);
            Destroy(inGameScoreText);
        }
        if (IsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
        else if (IsGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;

            Application.Quit();
        }
    }
    public void Die()
    {
        
        IsGameOver = true;
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
