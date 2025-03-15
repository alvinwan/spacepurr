using UnityEngine;

public class OkButtonController : MonoBehaviour
{
    public GameObject HelpMenu;

    public void OnClick()
    {
        HelpMenu.SetActive(false);
    }
}
