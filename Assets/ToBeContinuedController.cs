using UnityEngine;
using UnityEngine.EventSystems;

public class ToBeContinuedController : MonoBehaviour, IPointerDownHandler
{
    public GameObject Level;
    public GameObject Menu;


    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
