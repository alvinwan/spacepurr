using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour, IPointerClickHandler
{
    public LevelController Level;
    public void Start()
    {
        gameObject.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Level.OnLevelStart();
    }
}
