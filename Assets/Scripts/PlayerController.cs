using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    #region Public Vars
    public Vector2 tankPosition;
    public int returnSpeedDivider = 2; // Divider to determine speed of fish returning to safe zone
    public int moveSpeedDivider = 6; // Divider to determine speed of fish moving to its point
    public float safeDistance = 1.0f; // Max Distance from tank you are safe within when owner turns
    public static int zoneOneNumerator = 0; // Numerator for numerating across the points in zone 1
    public static int zoneTwoNumerator = 0; // Numerator for numerating across the points in zone 2
    public static int zoneThreeNumerator = 0; // Numerator for numerating across the points in zone 3
    public static int zoneNumPublic;
    public UnityEvent SeenEvent; // Event when owner sees player

    #endregion

    #region Private Vars
    private Vector2 targetPoint;
    private readonly float timeScaleBase = 0.01f; // Base for the lerp timescale
    private float timeScale; // For the vector2.Lerp
    private bool isMoving = false;
    private int zoneNum = 0;
    private List<List<Vector2>> zoneList = new List<List<Vector2>>(); // List of all the zones, used for getting the target points in a zone
    private static bool targetChange = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        zoneList = ZoneCreator.GetZoneList(); // Gets the list of zones from ZoneCreator
        if (zoneNum == 0)
        {
            targetPoint = zoneList[zoneNum][zoneOneNumerator];
        }
        else if (zoneNum == 1)
        {
            targetPoint = zoneList[zoneNum][zoneTwoNumerator];
        }
        else
        {
            targetPoint = zoneList[zoneNum][zoneThreeNumerator];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Makes player move to a point as long as button is held down
        if (Input.GetButton("Fire1"))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Resets the timescale for Vector2.Lerp
        if (Input.GetButtonDown("Fire1") || Input.GetButtonUp("Fire1"))
        {
            timeScale = timeScaleBase;
        }

        // Switches the zone the fish travels too, cannot happen while the move button is held and until it's close enough to the tank position. Pressing the button will switch zones
        if (!isMoving && (transform.position.magnitude - tankPosition.magnitude) <= 0.1f && Input.GetButtonDown("Fire2"))
        {
            zoneNum = (zoneNum + 1) % 3;
            zoneNumPublic = zoneNum;
            Debug.Log(zoneNum);
            if (zoneNum == 0)
            {
                targetPoint = zoneList[zoneNum][zoneOneNumerator];
            }
            else if (zoneNum == 1)
            {
                targetPoint = zoneList[zoneNum][zoneTwoNumerator];
            }
            else
            {
                targetPoint = zoneList[zoneNum][zoneThreeNumerator];
            }
        }
    }

    private void LateUpdate()
    {
        if (targetChange)
        {
            if (zoneNum == 0)
            {
                targetPoint = zoneList[zoneNum][zoneOneNumerator];
            }
            else if (zoneNum == 1)
            {
                targetPoint = zoneList[zoneNum][zoneTwoNumerator];
            }
            else
            {
                targetPoint = zoneList[zoneNum][zoneThreeNumerator];
            }
            targetChange = false;
            timeScale = timeScaleBase;
        }
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

    public static void ChangeTargetPoint()
    {
        targetChange = true;
    }

    public void CheckSeenByOwner()
    {
        float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), tankPosition);
        if (distance > safeDistance)
        {
            SeenEvent.Invoke();
        }
    }
}
