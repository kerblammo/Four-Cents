using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    [SerializeField] TMP_Text stationName;
    [SerializeField] Hotkey one;
    [SerializeField] Hotkey two;
    [SerializeField] Hotkey three;
    [SerializeField] Hotkey four;
    public void RefreshLabels(string station, string first, string second, string third, string fourth)
    {
        stationName.text = station;
        if (first == "")
        {
            one.Hide();
        } else
        {
            one.Show();
            one.UpdateLabel(first);
        }

        if (second == "")
        {
            two.Hide();
        }
        else
        {
            two.Show();
            two.UpdateLabel(second);
        }

        if (third == "")
        {
            three.Hide();
        }
        else
        {
            three.Show();
            three.UpdateLabel(third);
        }

        if (fourth == "")
        {
            four.Hide();
        }
        else
        {
            four.Show();
            four.UpdateLabel(fourth);
        }
    }
}
