using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTile : MonoBehaviour
{
    public NavTile UpNeighbour;
    public NavTile DownNeighbour;
    public NavTile LeftNeighbour;
    public NavTile RightNeighbour;

    public StationHotkeys stationHotkeys;
}
