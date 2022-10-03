using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    [SerializeField] Button button;
    
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

    public void Lock()
    {
        button.interactable = false;
    }

    public void Unlock()
    {
        button.interactable = true;
    }
}
