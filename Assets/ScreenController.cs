using UnityEngine;
using System.Collections;

public class ScreenController : MonoBehaviour
{
    public GameObject ScreenOff;

    public SwitchController Switch;

    private IEnumerator Coroutine;
    
    private IEnumerator FlashPowerOffScreen()
    {
        for (int i = 0; i < 3; i++)
        {
            ScreenOff.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            ScreenOff.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnPowerButtonClick()
    {
        if (Switch.GetIsOn())
        {
            // TODO: implement
            Debug.Log("Screen ready to show data");;
        }
        else
        {
            Debug.Log("Screen flashing no power");
            Coroutine = FlashPowerOffScreen();
            StartCoroutine(Coroutine);
        }
    }
    public void Start()
    {
        ScreenOff.SetActive(false);
    }
}
