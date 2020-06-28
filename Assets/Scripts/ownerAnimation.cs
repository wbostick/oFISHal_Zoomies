using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownerAnimation : MonoBehaviour
{
    public float faceChangeTime;
    public bool turnActivated = false;
    public bool ownerIsLooking = false;
    public Animator animator;


    public float[] turnTimes;
 

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        StartCoroutine(faceRandomizer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeFace()
    {
        animator.SetInteger("whichOwner", Random.Range(1, 6));
    }

    public void activateTurn()
    {
        turnActivated = true;
        animator.SetInteger("whichOwner", 0);
        StartCoroutine(turnPhaseChange(1));
    }

    IEnumerator faceRandomizer()
    {
        yield return new WaitForSeconds(faceChangeTime);
        if (turnActivated == false)
        {
            changeFace();
            StartCoroutine(faceRandomizer());
        }
        
    }
    IEnumerator turnPhaseChange(int phase)
    {
        yield return new WaitForSeconds(turnTimes[phase - 1]);
        if (phase == turnTimes.Length)
        {
            turnActivated = false;
            ownerIsLooking = false;
            changeFace();
            StartCoroutine(faceRandomizer());
        }
        else
        {
            if (phase == 2)
            {
                ownerIsLooking = true;
            }
            animator.SetInteger("turnPhase", phase + 1);
            StartCoroutine(turnPhaseChange(phase + 1));
        }

    }
}
