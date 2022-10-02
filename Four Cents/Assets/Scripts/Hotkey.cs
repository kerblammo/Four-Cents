using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hotkey : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    
    public void Hide()
    {
        gameObject.SetActive(false);
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void UpdateLabel(string text)
    {
        label.text = text;
    }
}
