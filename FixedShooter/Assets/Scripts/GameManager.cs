using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int Lives { get; private set; }
    public int Deaths { get; private set; }
    public int Scores { get; private set; }
    public float Timer { get; private set; }

    public static GameManager Instance { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnDeathsChanged;
    public event Action<float> OnTimerChanged;

    private int currentLevelIndex;
    private bool isTimerOn;
    private float currentTimer;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Deaths = 0;
            Scores = 0;
            Timer = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
    }

    private void Update()
    {
        CountTime();
    }

    public void CountTime()
    {
        if (currentLevelIndex < 1 || currentLevelIndex >= 4)
        {
            isTimerOn = false;
            currentTimer = Timer;
        }
        else
        {
            isTimerOn = true;
            if (isTimerOn)
                Timer += Time.deltaTime;

            OnTimerChanged?.Invoke(Timer);
        }
    }

    internal void KillPlayer()
    {
        Lives--;
        if (OnLivesChanged != null)
            OnLivesChanged(Lives);

        if (Lives <= 0)
        {
            Deaths++;
            if (OnDeathsChanged != null)
                OnDeathsChanged(Deaths);
        }

    }

    public void MoveToNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }

    public void MoveToLevel()
    {
        currentLevelIndex = 0;
        currentLevelIndex++;
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        Lives = 3;
        Scores = 0;
        Timer = 0;

        SceneManager.LoadScene(currentLevelIndex);

    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    internal void AddScore(int points)
    {
        Scores += points;

        OnScoreChanged?.Invoke(Scores);
    }
}
