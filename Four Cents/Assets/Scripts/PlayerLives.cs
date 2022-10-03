using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    int currentLife;
    public int CurrentLife { get => currentLife; }
    const int maxLife = 3;

    private void Start()
    {
        ResetLives();
    }

    public void ResetLives()
    {
        currentLife = maxLife;
    }

    public void DeductLife()
    {
        currentLife--;
    }

}
