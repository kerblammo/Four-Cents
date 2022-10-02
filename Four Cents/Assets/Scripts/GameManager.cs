using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CustomerQueue customerQueue;
    public void GameOver()
    {
        customerQueue.GameOver();
        Debug.Log("Game Over!");
    }

    public void BeginGame()
    {
        customerQueue.BeginGame();
    }

    private void Start()
    {
        BeginGame(); //TODO: Move this from Start and attach it to a button or something
    }

}
