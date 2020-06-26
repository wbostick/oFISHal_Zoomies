using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Vars
    public Vector2 tankPosition;
    public Vector2 targetPoint;
    public int returnSpeedDivider = 2; // Divider to determine speed of fish returning to safe zone
    public int moveSpeedDivider = 6; // Divider to determine speed of fish moving to its point
    public static int zoneOneNumerator = 0; // Numerator for numerating across the points in zone 1
    public static int zoneTwoNumerator = 0; // Numerator for numerating across the points in zone 2
    public static int zoneThreeNumerator = 0; // Numerator for numerating across the points in zone 3
    #endregion

    #region Private Vars
    private readonly float timeScaleBase = 0.01f; // Base for the lerp timescale
    private float timeScale; // For the vector2.Lerp
    private bool isMoving = false;
    private int zoneNum = 0;
    private List<List<Vector2>> zoneList = new List<List<Vector2>>(); // List of all the zones, used for getting the target points in a zone
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        zoneList = ZoneCreator.GetZoneList(); // Gets the list of zones from ZoneCreator
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

        // Resets the timescale for Vector2.Lerp
        if(Input.GetButtonDown("Fire1") || Input.GetButtonUp("Fire1"))
        {
            timeScale = timeScaleBase;
        }

        // Switches the zone the fish travels too, cannot happen while the move button is held and until it's close enough to the tank position. Pressing the button will switch zones
        if (!isMoving && (transform.position.magnitude - tankPosition.magnitude) <= Mathf.Epsilon && Input.GetButtonDown("Fire2"))
        {
            zoneNum = (zoneNum + 1) % 3;
        }
    }


    // For the zone system the object itself will have an onTriggerEnter with the fish and then broadcast that it is "destroyed" and moves its respective zone numerator up by 1

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        // Calls the functions to move the fish
        if (isMoving)
        {
            MoveToPoint(targetPoint);
        }
        else
        {
            ReturnToTank();
        }
    }


    // Lerps the fish to tankPosition
    private void ReturnToTank()
    {
        transform.position = Vector2.Lerp(transform.position, tankPosition, timeScale);
        timeScale += Time.deltaTime / returnSpeedDivider;
    }

    // Lerps the fish to targetPosition
    private void MoveToPoint(Vector2 targetPosition)
    {
        transform.position = Vector2.Lerp(transform.position, targetPosition, timeScale);
        timeScale += Time.deltaTime / moveSpeedDivider;
    }

}
