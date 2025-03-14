using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwitchController : MonoBehaviour, IPointerClickHandler
{
    // Game objects
    public RectTransform SwitchRect;

    // Internal state
    private bool isOn = false;
    private Vector3 StartPosition;

    // Listeners
    public event Action<bool> OnSwitchToggled;

    public bool GetIsOn()
    {
        return isOn;
    }

    public void TurnOn()
    {
        isOn = true;
        Debug.Log("Switch is on");
        SwitchRect.anchoredPosition = StartPosition + Vector3.up * 5;
        OnSwitchToggled?.Invoke(isOn);
    }

    public void TurnOff()
    {
        isOn = false;
        Debug.Log("Switch is off");
        SwitchRect.anchoredPosition = StartPosition;
        OnSwitchToggled?.Invoke(isOn);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    void Toggle()
    {
        if (isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPosition = SwitchRect.anchoredPosition;
    }
}
