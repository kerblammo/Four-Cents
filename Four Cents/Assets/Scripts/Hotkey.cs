using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    [SerializeField] Button button;
    [SerializeField] Image icon;
    
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

    public void UpdateLabel(HotkeyData data)
    {
        label.text = data.label;
        icon.sprite = data.icon;
    }

    public void Lock()
    {
        button.interactable = false;
    }

    public void Unlock()
    {
        button.interactable = true;
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
