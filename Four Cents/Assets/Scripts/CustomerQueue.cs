using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    [SerializeField]
    GameObject CustomerPrefab;
    [SerializeField]
    Transform editorOrganizer;
    [SerializeField] float firstSpawnDelay = 3f;
    List<Customer> customers;
    int customersVisited = 0;

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

    public Order GetExpectedOrder()
    {
        return customers[0].CustomerOrder;
    }

    public bool AreCustomersWaiting() => customers.Count > 0;

    public void ServeNextCustomer()
    {
        Debug.Log("Customer served");
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
