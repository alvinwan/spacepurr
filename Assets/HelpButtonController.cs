using UnityEngine;
using TMPro;

public class HelpButtonController : MonoBehaviour
{
    public GameObject HelpMenu;
    public TMP_Text HintText;
    public SwitchController Switch;
    public ScreenController Screen;
    public PumpController Pump;
    public TankCapController TankCap;
    public TankController Tank;
    public LockController Lock;
    public GrateController Grate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HelpMenu.SetActive(false);
    }

    public void OnClick()
    {
        if (!Grate.GetIsCovered())
        {
            HintText.text = "You have now completed the first level. Space cat is now moving on to the next room!";
        }
        else if (!Tank.GetIsCovered())
        {
            HintText.text = "Space cat is now free from the cryogenic chamber! Now, let's find a way out of this room.";
        }
        else if (Tank.GetIsEmptied() && !Lock.GetIsLocked())
        {
            HintText.text = "The cryogenic tank is now empty and its locks are now unfastened. Wonder if it can be moved...";
        }
        else if (Tank.GetIsEmptied())
        {
            HintText.text = "The cryogenic tank is now empty, but unfortunately, it's still fastened with locks to the ground.";
        }
        else if (Screen.GetIsOn())
        {
            HintText.text = "You have turned on the power and booted the computer, but the water pump needs one more thing.";
        }
        else if (Switch.GetIsOn())
        {
            HintText.text = "The power is on! Let's see what devices can be now be turned on, in this chamber.";
        }
        else
        {
            HintText.text = "Help space cat escape the cryogenic tank and move on to the next room. To start, try some buttons!";
        }
        HelpMenu.SetActive(true);
    }
}
