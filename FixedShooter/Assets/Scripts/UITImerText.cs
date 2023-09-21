using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITImerText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        GameManager.Instance.OnTimerChanged += HandleOnTimerChanged;
        tmproText.text = GameManager.Instance.Timer.ToString("F2");
    }

    private void HandleOnTimerChanged(float time)
    {
        tmproText.text = time.ToString("F2");
    }
}
