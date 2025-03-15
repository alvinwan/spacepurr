using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TankController : MonoBehaviour
{
    // game objects
    public GameObject Water;
    public PumpController Pump;
    public CatController Cat;
    public TankCapController TankCap;

    void Start()
    {
        Pump.OnPumpReady += OnPumpReady;
    }

    public void OnPumpReady(bool _)
    {
        TankCap.Press();
        Water.SetActive(false);
        Cat.Awaken();
    }
}
