using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject ToBeContinued;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnLevelStart()
    {
        gameObject.SetActive(true);
        Menu.SetActive(false);
    }
    public void OnLevelEnd()
    {
        ToBeContinued.SetActive(true);
        gameObject.SetActive(false);
    }
}
