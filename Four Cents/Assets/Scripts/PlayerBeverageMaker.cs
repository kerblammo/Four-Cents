using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeverageMaker : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerNavigator navigator;
    [SerializeField] CustomerQueue customerQueue;
    Soundboard soundboard;

    private void Start()
    {
        soundboard = FindObjectOfType<Soundboard>();
    }
    public void HotKeyOne()
    {
        switch (navigator.GetCurrentStation())
        {
            case Stations.Cash:
                player.GetOrder().PayForOrder();
                soundboard.PlayCashRegister();
                soundboard.PlayCustomerNoise();
                break;
            case Stations.Cups:
                player.GetOrder().SetCupSize(OrderSizes.Small);
                break;
            case Stations.Fridge:
                player.GetOrder().SetDairyType(DairyTypes.Milk);
                soundboard.PlayFridge();
                break;
            case Stations.Coffee:
                player.GetOrder().MakeCoffee();
                soundboard.PlayLiquidPour();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Black);
                soundboard.PlayLiquidPour();
                break;
            case Stations.Extras:
                player.GetOrder().AddWhip();
                soundboard.PlayWhippedCreamSpray();
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Chocolate);
                soundboard.PlaySyrupPump();
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
                soundboard.PlayFridge();
                break;
            case Stations.Coffee:
                player.GetOrder().MakeEspresso();
                soundboard.PlayLiquidPour();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Green);
                soundboard.PlayLiquidPour();
                break;
            case Stations.Extras:
                player.GetOrder().AddIce();
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Vanilla);
                soundboard.PlaySyrupPump();
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
                soundboard.PlayFridge();
                break;
            case Stations.Coffee:
                player.GetOrder().SteamMilk();
                soundboard.PlayMilkSteamer();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Chai);
                soundboard.PlayLiquidPour();
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Caramel);
                soundboard.PlaySyrupPump();
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
                soundboard.PlayFridge();
                break;
            case Stations.Tea:
                player.GetOrder().SetTeaType(TeaTypes.Mint);
                soundboard.PlayLiquidPour();
                break;
            case Stations.Syrups:
                player.GetOrder().SetSyrupType(SyrupTypes.Hazelnut);
                soundboard.PlaySyrupPump();
                break;
        }

        navigator.RefreshStationUI();
    }
}
