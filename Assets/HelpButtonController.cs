using UnityEngine;

public class HelpButtonController : MonoBehaviour
{
    public GameObject HelpMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HelpMenu.SetActive(false);
    }

    public void OnClick()
    {
        HelpMenu.SetActive(true);
    }
}
