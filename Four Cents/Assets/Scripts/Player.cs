using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Order currentOrder;
    [SerializeField] PlayerNavigator navigator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
    }

    void MoveLeft()
    {
        navigator.NavigateLeft();
    }

    void MoveRight()
    {
        navigator.NavigateRight();
    }

    void MoveUp()
    {
        navigator.NavigateUp();
    }

    void MoveDown()
    {
        navigator.NavigateDown();
    }
}
