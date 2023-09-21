using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDeathCounts : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnDeathsChanged += HandleOnDeathsChanged;
        tmproText.text = GameManager.Instance.Deaths.ToString();
    }

    private void HandleOnDeathsChanged(int deaths)
    {
        tmproText.text = deaths.ToString();   
    }
}
