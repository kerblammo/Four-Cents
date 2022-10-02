using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationHotkeys : MonoBehaviour
{
    [SerializeField] string stationName;
    [SerializeField] string hotkey1;
    [SerializeField] string hotkey2;
    [SerializeField] string hotkey3;
    [SerializeField] string hotkey4;

    [SerializeField] TaskUI taskUI;

    public void UpdateUI()
    {
        taskUI.RefreshLabels(stationName, hotkey1, hotkey2, hotkey3, hotkey4);
    }
}
