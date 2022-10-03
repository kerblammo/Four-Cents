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
            one.Unlock();
        }

        if (second == "")
        {
            two.Hide();
        }
        else
        {
            two.Show();
            two.UpdateLabel(second);
            two.Unlock();
        }

        if (third == "")
        {
            three.Hide();
        }
        else
        {
            three.Show();
            three.UpdateLabel(third);
            three.Unlock();
        }

        if (fourth == "")
        {
            four.Hide();
        }
        else
        {
            four.Show();
            four.UpdateLabel(fourth);
            four.Unlock();
        }
    }

    public void LockButton(int button)
    {
        if (button > 4 || button < 0)
        {
            throw new System.ArgumentOutOfRangeException("int button should be in range 1-4");
        }

        switch (button)
        {
            case 1:
                one.Lock();
                break;
            case 2:
                two.Lock();
                break;
            case 3:
                three.Lock();
                break;
            case 4:
                four.Lock();
                break;
        }

    }

    public void LockAllButtons()
    {
        LockButton(1);
        LockButton(2);
        LockButton(3);
        LockButton(4);
    }
}
