using UnityEngine;
using UnityEngine.EventSystems;


public class SwitchController : MonoBehaviour, IPointerClickHandler
{
    private bool isOn = false;

    public RectTransform SwitchRect;

    private Vector3 StartPosition;

    public bool GetIsOn()
    {
        return isOn;
    }

    public void TurnOn()
    {
        isOn = true;
        Debug.Log("Switch is on");
        SwitchRect.anchoredPosition = StartPosition + Vector3.up * 5;
    }

    public void TurnOff()
    {
        isOn = false;
        Debug.Log("Switch is off");
        SwitchRect.anchoredPosition = StartPosition;
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
