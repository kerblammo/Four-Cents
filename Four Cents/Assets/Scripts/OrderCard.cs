using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderCard : MonoBehaviour
{
    [SerializeField] TMP_Text orderName;

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

    public void UpdateOrder(string title, List<string> contents)
    {
        orderName.text = title;

        for (int i = 0; i < contents.Count; i++)
        {
            ingredientSlots[i].text = contents[i].ToLower();
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
}
