using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField]
    GameObject CustomerPrefab;
    List<Customer> customers;


    bool gameIsInPlay = true;

    private void Start()
    {
        customers = new List<Customer>();
    }
    void SpawnCustomer()
    {
        GameObject customer = Instantiate(CustomerPrefab);
        customers.Add(customer.GetComponent<Customer>());
        StartCoroutine(EveryTenSeconds());
    }

    IEnumerator EveryTenSeconds()
    {
        // Hey, it's the name of the jam!
        yield return new WaitForSeconds(10f);
        if (gameIsInPlay)
        {
            SpawnCustomer();
        }
        
    }

}
