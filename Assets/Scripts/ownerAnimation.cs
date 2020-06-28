using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownerAnimation : MonoBehaviour
{
    public float faceChangeTime;
    public bool turnActivated = false;
    public bool ownerIsLooking = false;
    public Animator animator;
    public AudioSource audioComp;

    public PlayerController player;


    public float[] turnTimes;
 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerController>();
        
        animator = GetComponent<Animator>();
        audioComp = GetComponent<AudioSource>();
        StartCoroutine(faceRandomizer());
    }

    // Update is called once per frame
    void Update()
    {
        if (ownerIsLooking)
        {
            player?.CheckSeenByOwner();
        }
    }

    void changeFace()
    {
        animator.SetInteger("whichOwner", Random.Range(1, 6));
    }

    public void activateTurn()
    {
        SetSpeaking(false);
        turnActivated = true;
        animator.SetInteger("whichOwner", 0);
        StartCoroutine(turnPhaseChange(1));
    }

    IEnumerator faceRandomizer()
    {
        SetSpeaking(true);
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

    public void SetSpeaking(bool bShouldSpeak)
    {
        if (bShouldSpeak)
        {
            audioComp.Play();
        }
        else
        {
            audioComp.Pause();
        }
    }
}
