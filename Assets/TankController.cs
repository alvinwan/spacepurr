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
    public GrateController Grate;
    public LockController Locks;
    public AudioSource ThunkSound;
    public AudioSource DrainWaterSound;

    // internal state
    private bool isEmptied = false;

    public bool GetIsEmptied()
    {
        return isEmptied;
    }

    void Start()
    {
        Pump.OnPumpReady += OnPumpReady;
        Grate.OnGrateToggled += OnGrateToggled;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isEmptied || Locks.GetIsLocked())
        {
            return;
        }
        ThunkSound.Play();
        TankCover.SetActive(false);
        TankCap.gameObject.SetActive(false);
    }

    public void OnGrateToggled(bool isCovered)
    {
        if (isCovered)
        {
            return;
        }
        Cat.gameObject.SetActive(false);
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
        DrainWaterSound.Play();
    }
}
