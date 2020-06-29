using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runStart()
    {
        animator.SetBool("running", true);
    }
    public void runStop()
    {
        animator.SetBool("running", false);
    }
    public void kick()
    {
        animator.SetBool("running", false);
        animator.SetTrigger("kick");
    }
    public void jump()
    {
        animator.SetTrigger("jump");
    }
    public void land()
    {
        animator.SetTrigger("land");
    }
    IEnumerator landToIdle()
    {
        yield return new WaitForSeconds((32f/60f));
        Vector2 targetPosition = new Vector2(transform.position.x + 2.3f, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPosition, 0.25f);
    }
}
