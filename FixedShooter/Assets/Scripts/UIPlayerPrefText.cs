using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerPrefText : MonoBehaviour
{
    [SerializeField] string key;

    private void OnEnable()
    {
        int value = PlayerPrefs.GetInt(key);
        GetComponent<TMP_Text>().SetText(value.ToString());
    }
}
