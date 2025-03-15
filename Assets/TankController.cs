using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TankController : MonoBehaviour, IPointerDownHandler
{
    // game objects
    public GameObject Water;
    public PumpController Pump;
    public CatController Cat;
    public TankCapController TankCap;
    public GameObject TankCover;

    // internal state
    private bool isEmptied = false;

    void Start()
    {
        Pump.OnPumpReady += OnPumpReady;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isEmptied)
        {
            return;
        }
        TankCover.SetActive(false);
        TankCap.gameObject.SetActive(false);
    }

    public void OnPumpReady(bool _)
    {
        if (isEmptied)
        {
            return;
        }
        isEmptied = true;
        TankCap.Press();
        Water.SetActive(false);
        Cat.Awaken();
    }
}
