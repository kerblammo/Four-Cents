using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeverageMaker : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerNavigator navigator;
    [SerializeField] CustomerQueue customerQueue;
    public void HotKeyOne()
    {
        switch (navigator.GetCurrentStation())
        {
            case Stations.Cash:
                player.GetOrder().PayForOrder();
                break;
            case Stations.Cups:
                player.GetOrder().SetCupSize(OrderSizes.Small);
                break;
            case Stations.Fridge:
                player.GetOrder().SetDairyType(DairyTypes.Milk);
                break;
            case Stations.Coffee:
                player.GetOrder().MakeCoffee();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Black);
                break;
            case Stations.Extras:
                player.GetOrder().AddWhip();
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Chocolate);
                break;
            case Stations.Serve:
                Order currentOrder = player.GetOrder();
                Order customerOrder = customerQueue.GetExpectedOrder();
                if (currentOrder.CompareToOrder(customerOrder))
                {
                    Debug.Log("Yah");
                    //TODO: Serve customer and move the queue along
                } else
                {
                    //TODO: Serve customer, move the queue along, and deduct a life
                    Debug.Log("Nah");
                }
                currentOrder.FreshNewOrder();
                break;
            
        }

        navigator.RefreshStationUI();
        
    }

    public void HotKeyTwo()
    {
        switch (navigator.GetCurrentStation())
        {
            case Stations.Cups:
                player.GetOrder().SetCupSize(OrderSizes.Medium);
                break;
            case Stations.Fridge:
                player.GetOrder().SetDairyType(DairyTypes.Soy);
                break;
            case Stations.Coffee:
                player.GetOrder().MakeEspresso();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Green);
                break;
            case Stations.Extras:
                player.GetOrder().AddIce();
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Vanilla);
                break;
        }

        navigator.RefreshStationUI();
    }

    public void HotKeyThree()
    {
        switch (navigator.GetCurrentStation())
        {
            case Stations.Cups:
                player.GetOrder().SetCupSize(OrderSizes.Large);
                break;
            case Stations.Fridge:
                player.GetOrder().SetDairyType(DairyTypes.Almond);
                break;
            case Stations.Coffee:
                player.GetOrder().SteamMilk();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Chai);
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Caramel);
                break;
        }

        navigator.RefreshStationUI();
    }

    public void HotKeyFour()
    {
        switch (navigator.GetCurrentStation())
        {
            case Stations.Fridge:
                player.GetOrder().SetDairyType(DairyTypes.Oat);
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Mint);
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Hazelnut);
                break;
        }

        navigator.RefreshStationUI();
    }
}
