using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public LevelController Level;
    public void Start()
    {
        gameObject.SetActive(true);
    }
    public void OnStartClicked()
    {
        Level.OnLevelStart();
    }
}
