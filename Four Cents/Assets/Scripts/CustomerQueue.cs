using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField]
    GameObject CustomerPrefab;
    [SerializeField] CustomerAnimation animator;
    [SerializeField]
    Transform editorOrganizer;
    [SerializeField] float firstSpawnDelay = 3f;
    List<Customer> customers;
    int customersVisited = 0;
    int customersServed = 0;
    public int CustomersServed { get => customersServed; }

    [SerializeField] List<GameObject> orderCards;
    

    bool gameIsInPlay = true;

    private void Start()
    {
        HideOrderCards();
    }

    void HideOrderCards()
    {
        foreach (GameObject card in orderCards)
        {
            card.GetComponent<OrderCard>().ClearOrder();
            card.SetActive(false);
        }
    }

    void AssignAllCards()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            Customer customer = customers[i];
            customer.AssignCard(orderCards[i].GetComponent<OrderCard>());
        }
    }

    public void GameOver()
    {
        gameIsInPlay = false;
        StopAllCoroutines();
    }

    public void BeginGame()
    {
        customers = new List<Customer>();
        StartCoroutine(FirstSpawn());
    }

    public void DisplayNextCustomerOrder()
    {
        customers[0].DisplayOrder();
    }

    public Order GetExpectedOrder()
    {
        return customers[0].CustomerOrder;
    }

    public bool AreCustomersWaiting() => customers.Count > 0;

    public void ServeNextCustomer()
    {
        customersServed++;
        Customer customer = customers[0];
        Destroy(customer.gameObject);
        customers.RemoveAt(0);
        HideOrderCards();
        AssignAllCards();
        animator.AnimateCustomers(customers.Count);
    }
    IEnumerator FirstSpawn()
    {
        yield return new WaitForSeconds(firstSpawnDelay);
        SpawnCustomer();
    }
    void SpawnCustomer()
    {
        GameObject customer = Instantiate(CustomerPrefab);
        Customer script = customer.GetComponent<Customer>();
        int index = customers.Count;
        if (index >= 5)
        {
            FindObjectOfType<GameManager>().GameOver();
            return;
        }
        customers.Add(script);
        script.AssignCard(orderCards[index].GetComponent<OrderCard>());
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

        script.HideOrderUntilTaken();
        customersVisited++;
        animator.AnimateCustomers(customers.Count);
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
