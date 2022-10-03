using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] CustomerQueue customerQueue;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameStartPanel;
    [SerializeField] TMP_Text scoreDisplay;

    public void GameOver()
    {
        customerQueue.GameOver();
        int customersServed = customerQueue.CustomersServed;
        string display = $"Your job was given to a robot, but at least you earned a final paycheque of ${customersServed * 0.04} for serving {customersServed} customers.\n\nHope you can retire on that!";
        scoreDisplay.text = display;
        gameOverPanel.SetActive(true);
    }

    public void BeginGame()
    {
        gameStartPanel.SetActive(false);
        customerQueue.BeginGame();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

}
