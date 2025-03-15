using UnityEngine;

public class CatController : MonoBehaviour
{
    // internal state
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Awaken()
    {
        animator.SetTrigger("awaken");
    }
}
