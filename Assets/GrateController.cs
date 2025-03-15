using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GrateController : MonoBehaviour, IPointerDownHandler
{
    // game objects
    public GameObject GrateCover;
    public GameObject GrateCoverDiscard;
    public TankController Tank;

    // internal state
    private bool isCovered = true;

    // listeners
    public event Action<bool> OnGrateToggled;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isCovered || !Tank.GetIsEmptied())
        {
            return;
        }
        isCovered = false;
        GrateCover.SetActive(false);
        GrateCoverDiscard.SetActive(true);
        OnGrateToggled?.Invoke(isCovered);
    }
}
