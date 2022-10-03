using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Soundboard : MonoBehaviour
{
    [SerializeField] AudioMixer BGM;
    [SerializeField] AudioMixer SFX;

    [SerializeField] SoundboardSnippet milkSteamer;
    [SerializeField] SoundboardSnippet customers;
    [SerializeField] SoundboardSnippet cashRegister;
    [SerializeField] SoundboardSnippet fridge;
    [SerializeField] SoundboardSnippet orderCardShuffle;
    [SerializeField] SoundboardSnippet liquidPour;
    [SerializeField] SoundboardSnippet whippedCreamSpray;
    [SerializeField] SoundboardSnippet syrupPump;
    [SerializeField] SoundboardSnippet cup;
    [SerializeField] SoundboardSnippet ice;
    [SerializeField] SoundboardSnippet success;
    [SerializeField] SoundboardSnippet fail;

    public void MuteSFX()
    {
        SFX.SetFloat("Volume", -80);
    }

    public void MuteBGM()
    {
        BGM.SetFloat("Volume", -80);
    }

    public void EnableSFX()
    {
        SFX.SetFloat("Volume", 0);
    }

    public void EnableBGM()
    {
        BGM.SetFloat("Volume", 0);
    }

    public void PlayMilkSteamer()
    {
        milkSteamer.PlaySound();
    }

    public void PlayCustomerNoise()
    {
        customers.PlaySound();
    }

    public void PlayCashRegister()
    {
        cashRegister.PlaySound();
    }

    public void PlayFridge()
    {
        fridge.PlaySound();
    }

    public void PlayOrderCardShuffle()
    {
        orderCardShuffle.PlaySound();
    }

    public void PlayLiquidPour()
    {
        liquidPour.PlaySound();
    }

    public void PlayWhippedCreamSpray()
    {
        whippedCreamSpray.PlaySound();
    }

    public void PlaySyrupPump()
    {
        syrupPump.PlaySound();
    }

    public void PlayIce()
    {
        ice.PlaySound();
    }

    public void PlayCup()
    {
        cup.PlaySound();
    }

    public void PlaySuccess()
    {
        success.PlaySound();
    }

    public void PlayFail()
    {
        fail.PlaySound();
    }
}
