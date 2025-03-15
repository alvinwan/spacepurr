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
    public TankCapController TankCap;
    public AudioSource FailSound;

    // internal state
    private IEnumerator Coroutine;

    // listeners
    public event Action<bool> OnPumpReady;

    public bool IsPump1On()
    {
        return Switch.GetIsOn();
    }

    public bool IsPump2On()
    {
        return Screen.GetIsOn();
    }

    public bool IsPump3On()
    {
        return TankCap.GetIsPressed();
    }

    public void LoadReadyState(bool _ = false)
    {
        PumpLight1.gameObject.SetActive(IsPump1On());
        PumpLight2.gameObject.SetActive(IsPump2On());
        PumpLight3.gameObject.SetActive(IsPump3On());
    }

    public void OnPowerButtonClick()
    {
        if (IsPump1On() && IsPump2On() && IsPump3On())
        {
            Debug.Log("Pump is on");
            OnPumpReady?.Invoke(true);
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
            FailSound.Play();
            yield return new WaitForSeconds(0.5f);
            if (!IsPump1On()) PumpLight1.gameObject.SetActive(false);
            if (!IsPump2On()) PumpLight2.gameObject.SetActive(false);
            if (!IsPump3On()) PumpLight3.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        // Just to make doubly sure that the state is restored
        LoadReadyState();
    }

    public void Start()
    {
        LoadReadyState();
        Switch.OnSwitchToggled += LoadReadyState;
        Screen.OnScreenToggled += LoadReadyState;
        TankCap.OnTankCapToggled += LoadReadyState;
    }
}
