using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    Order customerOrder;

    private void Start()
    {
        customerOrder.FreshNewOrder();
    }

    public void NewOrder()
    {
        customerOrder.GenerateNewOrder();
    }

    public void SimpleCoffeeOrder()
    {
        customerOrder.GenerateBlackCoffee();
    }

    public void SimpleTeaOrder()
    {
        customerOrder.GenerateSimpleTea();
    }

    public void SimpleLatteOrder()
    {
        customerOrder.GenerateSimpleLatte();
    }

    public void SimpleCocoaOrder()
    {
        customerOrder.GenerateSimpleCocoa();
    }

    public void DisplayOrder()
    {
        customerOrder.LogOrder();
    }
}
