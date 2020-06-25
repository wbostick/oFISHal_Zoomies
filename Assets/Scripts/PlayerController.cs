using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Vars
    public Vector2 tankPosition;
    public Vector2 targetPoint;
    #endregion

    #region Private Vars
    private readonly float timeScaleBase = 0.01f; // Base for the lerp timescale
    private float timeScale; 
    private bool isMoving = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Makes player move to a point as long as button is held down
        if(Input.GetButton("Fire1"))  
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if(Input.GetButtonDown("Fire1") || Input.GetButtonUp("Fire1"))
        {
            timeScale = timeScaleBase;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            MoveToPoint(targetPoint);
        }
        else
        {
            ReturnToTank();
        }
    }

    private void ReturnToTank()
    {
        transform.position = Vector2.Lerp(transform.position, tankPosition, timeScale);
        timeScale += Time.deltaTime / 2;
    }

    private void MoveToPoint(Vector2 targetPosition)
    {
        transform.position = Vector2.Lerp(transform.position, targetPosition, timeScale);
        timeScale += Time.deltaTime / 6;
    }

}
