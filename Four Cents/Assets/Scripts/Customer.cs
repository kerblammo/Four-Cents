using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    Order orderPrefab;
    Order customerOrder;
    public Order CustomerOrder { get => customerOrder; }


    OrderCard card;
    string customerName; // Steve, Burt, etc

    private void Start()
    {
        AssignName();
    }


    public void NewOrder()
    {
        customerOrder.GenerateNewOrder();
        DisplayOrder();
    }

    public void SimpleCoffeeOrder()
    {
        customerOrder.GenerateBlackCoffee();
        DisplayOrder();
    }

    public void SimpleTeaOrder()
    {
        customerOrder.GenerateSimpleTea();
        DisplayOrder();
    }

    public void SimpleLatteOrder()
    {
        customerOrder.GenerateSimpleLatte();
        DisplayOrder();
    }

    public void SimpleCocoaOrder()
    {
        customerOrder.GenerateSimpleCocoa();
        DisplayOrder();
    }

    public void DisplayOrder()
    {
        if (customerOrder == null) { GenerateOrderIfNull(); }
        List<string> ingredients = customerOrder.PrintIngredients();
        if (customerName == null)
        {
            AssignName();
        }
        string orderName = $"{customerName}'s {customerOrder.GetBeverageName()}";
        
        card.UpdateOrder(orderName, ingredients);

    }

    public void AssignCard(OrderCard orderCard)
    {
        if (card != null)
        {
            card.ClearOrder();
        }
        card = orderCard;
        DisplayOrder();
    }

    void AssignName()
    {
        List<string> namePool = new List<string>()
        {
            "Steve",
            "Paul",
            "Peter",
            "Larry",
            "Gary",
            "Jorje",
            "Javi",
            "Simon",
            "Alex",
            "Jeff",
            "Geoff",
            "Lance",
            "Henry",
            "Ethan",
            "Lloyd",
            "Tim",
            "Tom",
            "Aidan",
            "Abdul",
            "Akira",
            "Akeem",
            "Alfie",
            "Basil",
            "Champ",
            "Cesar",
            "Colin",
            "Diego",
            "Dwain",
            "Earl",
            "Frank",
            "Greg",
            "Hideo",
            "Irwin",
            "Jaime",
            "Jamie",
            "Karl",
            "Carl",
            "Keith",
            "Lyman",
            "Mario",
            "Mike",
            "Nigel",
            "Ollie",
            "Quinn",
            "Ramon",
            "Raoul",
            "Shawn",
            "Tariq",
            "Vince",
            "Waldo",
            "Yusef",
            "Zahir",
            "Agnes",
            "Abby",
            "Alana",
            "Alice",
            "Belle",
            "Betty",
            "Beula",
            "Brook",
            "Candy",
            "Carol",
            "Chloe",
            "Dawn",
            "Debby",
            "Donna",
            "Elena",
            "Emily",
            "Fanny",
            "Freya",
            "Gayle",
            "Grace",
            "Hazel",
            "Helen",
            "Holly",
            "Joan",
            "Janet",
            "Karen",
            "Kelly",
            "Lelah",
            "Lily",
            "Kat",
            "Linda",
            "Lori",
            "Mabel",
            "Maggy",
            "Mary",
            "Misty",
            "Nadia",
            "Nancy",
            "Naomi",
            "Nikki",
            "Olena",
            "Paige",
            "Pearl",
            "Penny",
            "Queen",
            "Piper",
            "Randy",
            "Ronda",
            "Robin",
            "Sandy",
            "Shena",
            "Sonja",
            "Tammy",
            "Terry",
            "Trudy",
            "Velma",
            "Vicky",
            "Wanda",
            "Wendy",
            "Zara",
            "Zelda",
        };

        int index = Random.Range(0, namePool.Count);
        customerName = namePool[index];
    }

    void GenerateOrderIfNull()
    {
        customerOrder = Instantiate(orderPrefab).GetComponent<Order>();
        customerOrder.FreshNewOrder();
    }
}
