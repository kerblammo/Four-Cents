using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimation : MonoBehaviour
{
    [SerializeField] Animator customer1;
    [SerializeField] Animator customer2;
    [SerializeField] Animator customer3;
    [SerializeField] Animator customer4;
    [SerializeField] Animator customer5;

    const string angry = "Angry";
    const string calm = "Calm";

    public void AnimateCustomers(int count)
    {
        string state;
        string opposite;
        if (count >= 3)
        {
            state = angry;
            opposite = calm;
        } else
        {
            state = calm;
            opposite = angry;
        }


        switch (count)
        {
            case 0:
                customer1.gameObject.SetActive(false);
                customer2.gameObject.SetActive(false);
                customer3.gameObject.SetActive(false);
                customer4.gameObject.SetActive(false);
                customer5.gameObject.SetActive(false);
                break;
            case 1:
                customer1.gameObject.SetActive(true);
                customer2.gameObject.SetActive(false);
                customer3.gameObject.SetActive(false);
                customer4.gameObject.SetActive(false);
                customer5.gameObject.SetActive(false);

                ToggleAnimation(customer1, state, opposite);
                break;
            case 2:
                customer1.gameObject.SetActive(true);
                customer2.gameObject.SetActive(true);
                customer3.gameObject.SetActive(false);
                customer4.gameObject.SetActive(false);
                customer5.gameObject.SetActive(false);

                ToggleAnimation(customer1, state, opposite);
                ToggleAnimation(customer2, state, opposite);
                break;
            case 3:
                customer1.gameObject.SetActive(true);
                customer2.gameObject.SetActive(true);
                customer3.gameObject.SetActive(true);
                customer4.gameObject.SetActive(false);
                customer5.gameObject.SetActive(false);

                ToggleAnimation(customer1, state, opposite);
                ToggleAnimation(customer2, state, opposite);
                ToggleAnimation(customer3, state, opposite);
                break;
            case 4:
                customer1.gameObject.SetActive(true);
                customer2.gameObject.SetActive(true);
                customer3.gameObject.SetActive(true);
                customer4.gameObject.SetActive(true);
                customer5.gameObject.SetActive(false);

                ToggleAnimation(customer1, state, opposite);
                ToggleAnimation(customer2, state, opposite);
                ToggleAnimation(customer3, state, opposite);
                ToggleAnimation(customer4, state, opposite);
                break;
            case 5:
                customer1.gameObject.SetActive(true);
                customer2.gameObject.SetActive(true);
                customer3.gameObject.SetActive(true);
                customer4.gameObject.SetActive(true);
                customer5.gameObject.SetActive(true);

                ToggleAnimation(customer1, state, opposite);
                ToggleAnimation(customer2, state, opposite);
                ToggleAnimation(customer3, state, opposite);
                ToggleAnimation(customer4, state, opposite);
                ToggleAnimation(customer5, state, opposite);
                break;

        }

    }

    private void ToggleAnimation(Animator customer, string state, string opposite)
    {
        customer.ResetTrigger(opposite);
        customer.SetTrigger(state);
    }
}
