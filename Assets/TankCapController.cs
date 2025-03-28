using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TankCapController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    // game objects
    public GameObject TankCap;
    public GameObject TankCapHighlighted;
    public GameObject TankCapPressed;
    public AudioSource CapOpenSound;
    public AudioSource CapCloseSound;

    // internal state
    private bool isPressed = false;
    private IEnumerator Coroutine;

    // listeners
    public event Action<bool> OnTankCapToggled;

    void Start()
    {
        SetState(0);
    }

    public void SetState(int state)
    {
        TankCap.SetActive(state == 0);
        TankCapHighlighted.SetActive(state == 1);
        TankCapPressed.SetActive(state == 2);
    }

    public void Press()
    {
        if (!isPressed)
        {
            isPressed = true;
            SetState(2);
            CapOpenSound.Play();
            OnTankCapToggled?.Invoke(isPressed);
        }

        if (Coroutine != null)
        {
            StopCoroutine(Coroutine);
        }
        Coroutine = ReleaseAfterDelay(3f);
        StartCoroutine(Coroutine);
    }

    public void Release()
    {
        isPressed = false;
        SetState(0);
        CapCloseSound.Play();
        OnTankCapToggled?.Invoke(isPressed);
    }

    public bool GetIsPressed()
    {
        return isPressed;
    }

    IEnumerator ReleaseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Release();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetState(1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isPressed)
        {
            SetState(0);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SetState(1);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!isPressed)
        {
            SetState(0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isPressed)
        {
            Press();
        }
    }
}
