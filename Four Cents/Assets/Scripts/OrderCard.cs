using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderCard : MonoBehaviour
{
    [SerializeField] TMP_Text orderName;

    [SerializeField] TMP_Text takeOrder;

    [SerializeField] List<Image> iconSlots;
    [SerializeField] List<TMP_Text> ingredientSlots;

    [Header("Icons")]
    [SerializeField] Sprite cupSmall;
    [SerializeField] Sprite cupMedium;
    [SerializeField] Sprite cupLarge;

    [SerializeField] Sprite milkDairy;
    [SerializeField] Sprite milkSoy;
    [SerializeField] Sprite milkAlmond;
    [SerializeField] Sprite milkOat;

    [SerializeField] Sprite coffee;
    [SerializeField] Sprite espresso;

    [SerializeField] Sprite teaBlack;
    [SerializeField] Sprite teaGreen;
    [SerializeField] Sprite teaChai;
    [SerializeField] Sprite teaMint;

    [SerializeField] Sprite syrupChocolate;
    [SerializeField] Sprite syrupVanilla;
    [SerializeField] Sprite syrupCaramel;
    [SerializeField] Sprite syrupHazelnut;

    [SerializeField] Sprite ice;
    [SerializeField] Sprite whippedCream;


    public void HideOrderUntilTaken()
    {
        ClearOrder();
        gameObject.SetActive(true);
        takeOrder.gameObject.SetActive(true);
        orderName.gameObject.SetActive(false);
    }
    public void DisplayOrder(string title, List<string> contents)
    {
        takeOrder.gameObject.SetActive(false);
        ClearOrder();
        orderName.text = title;
        orderName.gameObject.SetActive(true);

        for (int i = 0; i < contents.Count; i++)
        {
            string key = contents[i].ToLower();
            ingredientSlots[i].text = key;
            iconSlots[i].sprite = FetchIcon(key);
            iconSlots[i].gameObject.SetActive(true);
        }

        gameObject.SetActive(true);
    }

    public void ClearOrder()
    {
        gameObject.SetActive(false);
        foreach (Image icon in iconSlots)
        {
            icon.gameObject.SetActive(false);
        }

        foreach (TMP_Text ingredient in ingredientSlots)
        {
            ingredient.text = "";
        }
    }

    Sprite FetchIcon(string key)
    {
        if (key == "small cup") { return cupSmall; }
        else if (key == "medium cup") { return cupMedium; }
        else if (key == "large cup") { return cupLarge; }
        else if (key.Contains("soy milk")) { return milkSoy; }
        else if (key.Contains("almond milk")) { return milkAlmond; }
        else if (key.Contains("oat milk")) { return milkOat; }
        else if (key.Contains("milk")) { return milkDairy; } // do this milk last
        else if (key == "coffee") { return coffee; }
        else if (key == "espresso shot") { return espresso; }
        else if (key == "black tea") { return teaBlack; }
        else if (key == "green tea") { return teaGreen; }
        else if (key == "chai tea") { return teaChai; }
        else if (key == "mint tea") { return teaMint; }
        else if (key == "whipped cream") { return whippedCream; }
        else if (key == "ice") { return ice; }
        else if (key == "chocolate syrup") { return syrupChocolate; }
        else if (key == "vanilla syrup") { return syrupVanilla; }
        else if (key == "caramel syrup") { return syrupCaramel; }
        else if (key == "hazelnut syrup") { return syrupHazelnut; }
        else return null;
    }

}
