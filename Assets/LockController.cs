using UnityEngine;

public class LockController : MonoBehaviour
{
    // game objects
    public GameObject LockOn;
    public GameObject LockOff;
    public SwitchController Switch;

    public bool GetIsLocked()
    {
        return Switch.GetIsOn();
    }

    public void SetState(bool isLocked)
    {
        LockOn.SetActive(isLocked);
        LockOff.SetActive(!isLocked);
    }

    public void OnSwitchToggle(bool isSwitchOn)
    {
        SetState(isSwitchOn);
    }

    public void Start()
    {
        SetState(false);
        Switch.OnSwitchToggled += OnSwitchToggle;
    }
}
