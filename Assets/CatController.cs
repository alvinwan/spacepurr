using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour
{
    // internal state
    private Animator animator;
    private AudioSource MeowSound;

    public void Start()
    {
        animator = GetComponent<Animator>();
        MeowSound = GetComponent<AudioSource>();
    }

    public void Awaken()
    {
        animator.SetTrigger("awaken");
        StartCoroutine(Meow());
    }

    IEnumerator Meow()
    {
        yield return new WaitForSeconds(1f);
        MeowSound.Play();
        yield return new WaitForSeconds(5f);
        MeowSound.Play();
    }
}
