using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationHotkeys : MonoBehaviour
{
    [SerializeField] string stationName;
    [SerializeField] string hotkey1;
    [SerializeField] string hotkey2;
    [SerializeField] string hotkey3;
    [SerializeField] string hotkey4;

    [SerializeField] TaskUI taskUI;

    [SerializeField] Stations stationBehaviour;
    public Stations StationBehaviour { get => stationBehaviour; }

    public void UpdateUI(Order currentOrder)
    {
        
        taskUI.RefreshLabels(stationName, hotkey1, hotkey2, hotkey3, hotkey4);

        if (currentOrder == null) { return; }

        switch (stationBehaviour)
        {
            case Stations.Cash:
                CashStationBehaviour(currentOrder);
                break;
            case Stations.Fridge:
                FridgeStationBehaviour(currentOrder);
                break;
            case Stations.Coffee:
                CoffeeStationBehaviour(currentOrder);
                break;
            case Stations.Tea:
                TeaStationBehaviour(currentOrder);
                break;
            case Stations.Extras:
                ExtrasStationBehaviour(currentOrder);
                break;
            case Stations.Syrups:
                SyrupStationBehaviour(currentOrder);
                break;
            case Stations.Serve:
                ServeStationBehaviour(currentOrder);
                break;
            case Stations.Cups:
                CupStationBehaviour(currentOrder);
                break;
        }
    }

    void CashStationBehaviour(Order currentOrder)
    {
        CustomerQueue queue = FindObjectOfType<CustomerQueue>();
        if (currentOrder.HasBeenPaidFor || !queue.AreCustomersWaiting())
        {
            taskUI.LockButton(1);
        }
        
    }

    void FridgeStationBehaviour(Order currentOrder)
    {
        if (currentOrder.OrderSize == OrderSizes.Null)
        {
            taskUI.LockAllButtons();
        } else if (currentOrder.DairyType != DairyTypes.Null)
        {
            // only one type of milk is permitted
            taskUI.LockAllButtons();
        }
    }

    void CoffeeStationBehaviour(Order currentOrder)
    {
        if (currentOrder.OrderSize == OrderSizes.Null)
        {
            taskUI.LockAllButtons();
        } else
        {
            if (currentOrder.CoffeeType != CoffeeTypes.Null)
            {
                taskUI.LockButton(1);
                taskUI.LockButton(2);
            }
            if (currentOrder.DairyType == DairyTypes.Null || currentOrder.HasBeenSteamed)
            {
                taskUI.LockButton(3);
            } 
        }
    }

    void TeaStationBehaviour(Order currentOrder)
    {
        if (currentOrder.OrderSize == OrderSizes.Null)
        {
            taskUI.LockAllButtons();
        }
        else if (currentOrder.TeaType != TeaTypes.Null)
        {
            // only one type of tea is permitted
            taskUI.LockAllButtons();
        }
    }

    void ExtrasStationBehaviour(Order currentOrder)
    {
        if (currentOrder.OrderSize == OrderSizes.Null)
        {
            taskUI.LockAllButtons();
        }
        else
        {
            if (currentOrder.HasWhip)
            {
                taskUI.LockButton(1);
            }

            if (currentOrder.HasIce)
            {
                taskUI.LockButton(2);
            }
        }
        
    }

    void SyrupStationBehaviour(Order currentOrder)
    {
        if (currentOrder.OrderSize == OrderSizes.Null)
        {
            taskUI.LockAllButtons();
        } else
        {
            if (currentOrder.Syrups.Contains(SyrupTypes.Chocolate))
            {
                taskUI.LockButton(1);
            }

            if (currentOrder.Syrups.Contains(SyrupTypes.Vanilla))
            {
                taskUI.LockButton(2);
            }

            if (currentOrder.Syrups.Contains(SyrupTypes.Caramel))
            {
                taskUI.LockButton(3);
            }

            if (currentOrder.Syrups.Contains(SyrupTypes.Hazelnut))
            {
                taskUI.LockButton(4);
            }

        }
    }

    void ServeStationBehaviour(Order currentOrder)
    {
        if (!currentOrder.HasBeenPaidFor || currentOrder.OrderSize == OrderSizes.Null)
        {
            taskUI.LockAllButtons();
        }
    }

    void CupStationBehaviour(Order currentOrder)
    {

        if (currentOrder.OrderSize != OrderSizes.Null
            || !currentOrder.HasBeenPaidFor)
        {
            taskUI.LockAllButtons();
        }
    }
}

public enum Stations
{
    Null,
    Cash,
    Fridge,
    Coffee,
    Tea,
    Extras,
    Syrups,
    Serve,
    Cups
}
