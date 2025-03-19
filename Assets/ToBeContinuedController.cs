using UnityEngine;
using UnityEngine.EventSystems;

public class ToBeContinuedController : MonoBehaviour
{
    public GameObject Level;
    public GameObject Menu;


    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnButtonClick()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
