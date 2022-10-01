using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    Order customerOrder;

    private void Start()
    {
        customerOrder = customerOrder.GenerateNewOrder();
    }
}
