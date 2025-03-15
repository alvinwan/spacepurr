using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ScreenController : MonoBehaviour
{
    // game objects
    public GameObject ScreenOff;
    public GameObject ScreenOn;
    public SwitchController Switch;
    public AudioSource FailSound;
    public AudioSource PowerOnSound;

    // internal state
    private IEnumerator Coroutine;
    private bool isOn = false;

    // listener
    public event Action<bool> OnScreenToggled;
    
    private IEnumerator FlashPowerOffScreen()
    {
        for (int i = 0; i < 3; i++)
        {
            ScreenOff.SetActive(true);
            FailSound.Play();
            yield return new WaitForSeconds(0.5f);
            ScreenOff.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public bool GetIsOn()
    {
        return isOn;
    }

    public void TurnOff()
    {
        isOn = false;
        ScreenOn.SetActive(false);
        Debug.Log("Screen off");
        OnScreenToggled?.Invoke(false);
    }

    public void TurnOn()
    {
        isOn = true;
        ScreenOn.SetActive(true);
        Debug.Log("Turning screen on");
        OnScreenToggled?.Invoke(true);
        PowerOnSound.Play();
    }

    public void OnPowerButtonClick()
    {
        if (Switch.GetIsOn())
        {
            TurnOn();
        }
        else
        {
            Debug.Log("Screen flashing no power");
            Coroutine = FlashPowerOffScreen();
            StartCoroutine(Coroutine);
        }
    }

    public void OnSwitchToggled(bool isSwitchOn)
    {
        if (!isSwitchOn)
        {
            TurnOff();
        }
    }

    public void Start()
    {
        ScreenOff.SetActive(false);
        ScreenOn.SetActive(false);
        Switch.OnSwitchToggled += OnSwitchToggled;
    }
}
