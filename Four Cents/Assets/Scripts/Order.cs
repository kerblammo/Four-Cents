using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    bool hasBeenSteamed;
    public bool HasBeenSteamed { get => hasBeenSteamed; }
    bool hasIce;
    public bool HasIce { get => hasIce; }
    bool hasWhip;
    public bool HasWhip { get => hasWhip; }
    OrderSizes orderSize;
    public OrderSizes OrderSize { get => orderSize; }
    BeverageTypes beverageType;
    public BeverageTypes BeverageType { get => beverageType; }
    TeaTypes teaType;
    public TeaTypes TeaType { get => teaType; }
    CoffeeTypes coffeeType;
    public CoffeeTypes CoffeeType { get => coffeeType; }
    List<SyrupTypes> syrups;
    public List<SyrupTypes> Syrups { get => syrups; }
    DairyTypes dairyType;
    public DairyTypes DairyType { get => dairyType; }

    
    void FreshNewOrder()
    {
        hasBeenSteamed = false;
        hasIce = false;
        hasWhip = false;
        orderSize = OrderSizes.Null;
        beverageType = BeverageTypes.Null;
        teaType = TeaTypes.Null;
        dairyType = DairyTypes.Null;
        coffeeType = CoffeeTypes.Null;
        syrups = new List<SyrupTypes>();
    }

    public Order GenerateNewOrder()
    {
        syrups = new List<SyrupTypes>();
        orderSize = (OrderSizes)Random.Range(1, 3);
        beverageType = (BeverageTypes)Random.Range(1, 5);

        switch (beverageType)
        {
            case BeverageTypes.Cocoa:
                syrups.Add(SyrupTypes.Chocolate);
                break;
            case BeverageTypes.Coffee:
                coffeeType = CoffeeTypes.Coffee;
                break;
            case BeverageTypes.Espresso:
                coffeeType = CoffeeTypes.Espresso;
                break;
            case BeverageTypes.Tea:
                teaType = (TeaTypes)Random.Range(1, 5);
                break;
        }

        SelectDairyType();
        SelectIce();
        SelectWhip();

        SelectSyrupTypes();

        LogOrder();
        return this;
    }

    void SelectDairyType()
    {
        if (beverageType == BeverageTypes.Cocoa)
        {
            hasBeenSteamed = true;
            dairyType = (DairyTypes)Random.Range(1, 5);
        } else
        {
            dairyType = (DairyTypes)Random.Range(0, 5);
            if (dairyType != DairyTypes.Null)
            {
                hasBeenSteamed = Random.Range(0, 2) == 1; // if there's milk, half the time it's steamed 
            }
        }
    }

    void SelectIce()
    {
        if (beverageType == BeverageTypes.Cocoa)
        {
            hasIce = false;
        }
        else
        {
            hasIce = Random.Range(0, 5) == 1; // 1-in-4 chance there's ice in a non-cocoa drink
        }
    }

    void SelectWhip()
    {
        hasWhip = Random.Range(0, 2) == 1; // 1-in-2 chance there's whipped cream
    }

    void SelectSyrupTypes()
    {
        List<int> distribution = new List<int> { 0, 0, 1, 1, 1, 1, 2, 2, 3, 4 };
        int ceiling = distribution[Random.Range(0, distribution.Count)];

        List<SyrupTypes> availableSyrups = new List<SyrupTypes> {
            SyrupTypes.Chocolate, SyrupTypes.Vanilla, SyrupTypes.Caramel, SyrupTypes.Hazelnut
        };

        if (beverageType == BeverageTypes.Cocoa)
        {
            // Hot Cocoa always has chocolate, so it will not be a random selection
            ceiling--;
            availableSyrups.Remove(SyrupTypes.Chocolate);
        }

        availableSyrups = ShuffleList<SyrupTypes>(availableSyrups);

        for (int i = 0; i < ceiling; i++)
        {
            syrups.Add(availableSyrups[i]);
        }
    }

    private void LogOrder()
    {
        List<string> ingredients = PrintIngredients();
        string order = $"Customer {beverageType} Order:\n";
        foreach (string ingredient in ingredients)
        {
            order = order + $"{ingredient}\n";
        }
        Debug.Log(order);
    }

    public bool CompareToOrder(Order other)
    {
        bool isEqual = true;
        isEqual &= other.HasBeenSteamed == hasBeenSteamed;
        isEqual &= other.HasIce == hasIce;
        isEqual &= other.HasWhip == hasWhip;
        isEqual &= other.OrderSize == orderSize;
        isEqual &= other.BeverageType == beverageType;
        isEqual &= other.TeaType == teaType;
        isEqual &= other.DairyType == dairyType;
        isEqual &= other.CoffeeType == coffeeType;
        isEqual &= other.Syrups.Count == syrups.Count;
        foreach (SyrupTypes syrup in other.Syrups)
        {
            isEqual &= syrups.Contains(syrup);
        }
        return isEqual;
    }

    public List<string> PrintIngredients()
    {
        List<string> strings = new List<string>();

        strings.Add($"{orderSize.ToString()} Cup");
        switch (beverageType)
        {
            case BeverageTypes.Tea:
                switch (teaType)
                {
                    case TeaTypes.Black:
                        strings.Add("Black Tea");
                        break;
                    case TeaTypes.Green:
                        strings.Add("Green Tea");
                        break;
                    case TeaTypes.Chai:
                        strings.Add("Chai Tea");
                        break;
                    case TeaTypes.Mint:
                        strings.Add("Mint Tea");
                        break;
                }
                break;
            case BeverageTypes.Coffee:
                strings.Add("Coffee");
                break;
            case BeverageTypes.Espresso:
                strings.Add("Espresso Shot");
                break;
            case BeverageTypes.Cocoa:
                strings.Add("Chocolate Syrup");
                break;
        }

        List<string> randomOrderItems = new List<string>();

        if (hasIce) { randomOrderItems.Add("Ice"); }
        if (hasWhip) { randomOrderItems.Add("Whipped Cream"); }

        if (dairyType != DairyTypes.Null)
        {
            string milk = "";
            if (hasBeenSteamed) { milk = "Steamed "; }
            switch (dairyType)
            {
                case DairyTypes.Milk:
                    milk += "Milk";
                    break;
                case DairyTypes.Soy:
                    milk += "Soy Milk";
                    break;
                case DairyTypes.Almond:
                    milk += "Almond Milk";
                    break;
                case DairyTypes.Oat:
                    milk += "Oat Milk";
                    break;
            }
            randomOrderItems.Add(milk);

            foreach (SyrupTypes syrup in syrups)
            {
                if (syrup == SyrupTypes.Chocolate
                    && beverageType == BeverageTypes.Cocoa)
                {
                    continue; // chocolate syrup is already in the list
                }
                randomOrderItems.Add($"{syrup.ToString()} Syrup");
            }
        }
        randomOrderItems = ShuffleList(randomOrderItems);
        strings.AddRange(randomOrderItems);
        return strings;

    }

    /// <summary>
    /// Modifies list in place to randomly arrange items
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    List<T> ShuffleList<T>(List<T> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            T temp = items[i];
            int randomIndex = Random.Range(i, items.Count);
            items[i] = items[randomIndex];
            items[randomIndex] = temp;
        }

        return items;
    }
}

public enum OrderSizes
{
    Null,
    Small,
    Medium,
    Large
}

public enum BeverageTypes
{
    Null,
    Coffee,
    Espresso,
    Tea,
    Cocoa
}

public enum TeaTypes
{
    Null,
    Black,
    Green,
    Chai,
    Mint
}

public enum CoffeeTypes
{
    Null,
    Coffee,
    Espresso
}
public enum SyrupTypes
{
    Null,
    Chocolate,
    Vanilla,
    Caramel,
    Hazelnut
}

public enum DairyTypes
{
    Null,
    Milk,
    Soy,
    Almond,
    Oat
}
