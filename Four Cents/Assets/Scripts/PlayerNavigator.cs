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
        UpdatePlayerPosition();
    }

    public void NavigateLeft()
    {
        if (currentTile.LeftNeighbour != null)
        {
            currentTile = currentTile.LeftNeighbour;
            UpdatePlayerPosition();
        }
    }

    public void NavigateRight()
    {
        if (currentTile.RightNeighbour != null)
        {
            currentTile = currentTile.RightNeighbour;
            UpdatePlayerPosition();
        }
    }

    public void NavigateUp()
    {
        if (currentTile.UpNeighbour != null)
        {
            currentTile = currentTile.UpNeighbour;
            UpdatePlayerPosition();
        }
    }

    public void NavigateDown()
    {
        if (currentTile.DownNeighbour != null)
        {
            currentTile = currentTile.DownNeighbour;
            UpdatePlayerPosition();
        }
    }

    private void UpdatePlayerPosition()
    {
        Vector3 target = currentTile.transform.position;
        target.z = transform.position.z;
        transform.position = target;
    }
}
