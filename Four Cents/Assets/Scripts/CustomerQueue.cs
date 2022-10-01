using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField]
    GameObject CustomerPrefab;
    [SerializeField]
    Transform editorOrganizer;
    List<Customer> customers;
    int customersVisited = 0;


    bool gameIsInPlay = true;

    private void Start()
    {
        customers = new List<Customer>();
        SpawnCustomer();
    }
    void SpawnCustomer()
    {
        GameObject customer = Instantiate(CustomerPrefab);
        Customer script = customer.GetComponent<Customer>();
        customers.Add(script);
        customer.transform.parent = editorOrganizer;

        if (customersVisited == 0)
        {
            script.SimpleCoffeeOrder();
        } else if (customersVisited == 1)
        {
            script.SimpleTeaOrder();
        } else if (customersVisited == 2)
        {
            script.SimpleCocoaOrder();
        } else if (customersVisited == 3)
        {
            script.SimpleLatteOrder();
        } else
        {
            script.NewOrder();
        }

        script.DisplayOrder();
        customersVisited++;
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

    IEnumerator WaitTenSeconds()
    {
        yield return new WaitForSeconds(10f);
    }


}
