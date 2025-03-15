using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GrateController : MonoBehaviour, IPointerDownHandler
{
    // game objects
    public GameObject GrateCover;
    public GameObject GrateCoverDiscard;
    public GameObject Pawprints;
    public TankController Tank;
    public LevelController Level;

    // internal state
    private bool isCovered = true;

    // listeners
    public event Action<bool> OnGrateToggled;

    public void Start()
    {
        GrateCover.SetActive(true);
        GrateCoverDiscard.SetActive(false);
        Pawprints.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isCovered || !Tank.GetIsEmptied())
        {
            return;
        }
        isCovered = false;
        GrateCover.SetActive(false);
        GrateCoverDiscard.SetActive(true);
        Pawprints.SetActive(true);
        OnGrateToggled?.Invoke(isCovered);
        StartCoroutine(ToBeContinued());
    }

    public IEnumerator ToBeContinued()
    {
        yield return new WaitForSeconds(3f);
        Level.OnLevelEnd();
    }
}
