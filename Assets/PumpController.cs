using UnityEngine;
using System;
using System.Collections;

public class PumpController : MonoBehaviour
{
    // game objects
    public GameObject PumpLight1;
    public GameObject PumpLight2;
    public GameObject PumpLight3;
    public SwitchController Switch;
    public ScreenController Screen;

    // internal state
    private int readyLevel = 0;
    private IEnumerator Coroutine;

    public void SetReadyState(int level)
    {
        readyLevel = level;
        PumpLight1.gameObject.SetActive(level >= 1);
        PumpLight2.gameObject.SetActive(level >= 2);
        PumpLight3.gameObject.SetActive(level >= 3);
    }

    public void OnPowerButtonClick()
    {
        if (readyLevel == 3)
        {
            Debug.Log("Pump is on");
            // TODO: add water pumping here
        }
        else
        {
            Coroutine = FlashPumpLights();
            StartCoroutine(Coroutine);
            Debug.Log("Pump is not ready");
        }
    }

    public IEnumerator FlashPumpLights()
    {
        for (int i = 0; i < 3; i++)
        {
            PumpLight1.gameObject.SetActive(true);
            PumpLight2.gameObject.SetActive(true);
            PumpLight3.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            if (readyLevel < 1) PumpLight1.gameObject.SetActive(false);
            if (readyLevel < 2) PumpLight2.gameObject.SetActive(false);
            if (readyLevel < 3) PumpLight3.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        // Just to make doubly sure that the state is restored
        SetReadyState(readyLevel);
    }

    public void OnSwitchToggled(bool isSwitchOn)
    {
        if (isSwitchOn)
        {
            SetReadyState(1);
        }
        else
        {
            SetReadyState(0);
        }
    }

    public void OnScreenToggled(bool isScreenOn)
    {
        if (isScreenOn)
        {
            SetReadyState(2);
        }
        else
        {
            OnSwitchToggled(Switch.GetIsOn());
        }
    }

    public void Start()
    {
        SetReadyState(0);
        Switch.OnSwitchToggled += OnSwitchToggled;
        Screen.OnScreenToggled += OnScreenToggled;
    }
}
