using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
        tmproText.text = GameManager.Instance.Scores.ToString();
    }

    

    private void HandleOnScoreChanged(int score)
    {
        tmproText.text = score.ToString();
    }
}
