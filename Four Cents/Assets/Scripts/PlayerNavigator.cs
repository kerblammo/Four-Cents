using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigator : MonoBehaviour
{
    [SerializeField] List<NavTile> navTiles;
    [SerializeField] NavTile startingTile;
    NavTile currentTile;

    private void Start()
    {
        currentTile = startingTile;
        FinishNavigation();
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

    private void UpdatePlayerPosition()
    {
        Vector3 target = currentTile.transform.position;
        target.z = transform.position.z;
        transform.position = target;
    }

    private void UpdateUI()
    {
        currentTile.stationHotkeys.UpdateUI();
    }

    private void FinishNavigation()
    {
        UpdatePlayerPosition();
        UpdateUI();
    }
}
