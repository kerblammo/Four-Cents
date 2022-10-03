using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigator : MonoBehaviour
{
    [SerializeField] List<NavTile> navTiles;
    [SerializeField] NavTile startingTile;
    [SerializeField] Animator animator;
    [SerializeField] NavTile cashRegister;
    [SerializeField] CustomerQueue customerQueue;
    NavTile currentTile;
    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        currentTile = startingTile;
        FinishNavigation();
    }

    private void Update()
    {
        if (currentTile == cashRegister && customerQueue.AreCustomersWaiting())
        {
            cashRegister.stationHotkeys.UpdateUI(player.GetOrder());
        }
    }

    public void NavigateLeft()
    {
        if (currentTile.LeftNeighbour != null)
        {
            currentTile = currentTile.LeftNeighbour;
            FinishNavigation();
        }
    }

    public void NavigateRight()
    {
        if (currentTile.RightNeighbour != null)
        {
            currentTile = currentTile.RightNeighbour;
            FinishNavigation();
        }
    }

    public void NavigateUp()
    {
        if (currentTile.UpNeighbour != null)
        {
            currentTile = currentTile.UpNeighbour;
            FinishNavigation();
        }
    }

    public void NavigateDown()
    {
        if (currentTile.DownNeighbour != null)
        {
            currentTile = currentTile.DownNeighbour;
            FinishNavigation();
        }
    }

    public Stations GetCurrentStation()
    {
        return currentTile.stationHotkeys.StationBehaviour;
    }

    public void RefreshStationUI()
    {
        currentTile.stationHotkeys.UpdateUI(player.GetOrder());
    }

    private void UpdatePlayerPosition()
    {
        Vector3 target = currentTile.transform.position;
        target.z = transform.position.z;
        transform.position = target;
    }

    private void UpdateUI()
    {
        currentTile.stationHotkeys.UpdateUI(player.GetOrder());
    }

    private void FinishNavigation()
    {
        UpdatePlayerPosition();
        AnimatePlayer();
        UpdateUI();

    }

    void AnimatePlayer()
    {
        animator.ResetTrigger("Up");
        animator.ResetTrigger("Down");
        switch (currentTile.playerFacing)
        {
            case NavTile.CardinalDirections.Up:
                animator.SetTrigger("Up");
                break;
            case NavTile.CardinalDirections.Right:
                animator.SetTrigger("Right");
                break;
            case NavTile.CardinalDirections.Down:
                animator.SetTrigger("Down");
                break;
            case NavTile.CardinalDirections.Left:
                animator.SetTrigger("Left");
                break;
        }
    }
}
