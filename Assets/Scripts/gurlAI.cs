using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gurlAI : MonoBehaviour
{
    ownerAnimation ani;
    public GameObject gameOver;

    public float Min;
    public float Max;
    public float space;
    public float pauseTime;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<ownerAnimation>();
        StartCoroutine(turnGurl());
    }

    // Update is called once per frame
    void Update()
    {
        if (ani.ownerIsLooking && Input.GetButton("Fire1"))
        {
            StartCoroutine(endGame());
        }
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(pauseTime);
        gameOver.SetActive(true);
    }

    IEnumerator turnGurl()
    {
        yield return new WaitForSeconds(Random.Range(Min, Max));
        ani.activateTurn();
        yield return new WaitForSeconds(space);
        StartCoroutine(turnGurl());
    }
    
}
