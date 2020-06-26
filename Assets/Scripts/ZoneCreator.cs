using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCreator : MonoBehaviour
{   // Will create zones by seraching for game objects with tags, the tags determine what zone the object goes into. The game object gives its vector2 transform.position and stores it in its respective zone
    #region Public Vars

    #endregion

    #region Private Vars
    private static List<List<Vector2>> zones = new List<List<Vector2>>(); // A list of all the zones 
    private List<Vector2> zoneOneMovePoints = new List<Vector2>(); // List of Vector2 transform.position for objects in zone 1
    private List<Vector2> zoneTwoMovePoints = new List<Vector2>(); // List of Vector2 transform.position for objects in zone 2
    private List<Vector2> zoneThreeMovePoints = new List<Vector2>(); // List of Vector2 transform.position for objects in zone 3
    private GameObject[] objectsInZone; // Used to find objects in a zone and write their transform.position into a list
    #endregion

    void Awake()
    {
        // fills in the list zoneOneMovePoints with the transform.position of all objects with the tag "Zone 1"
        objectsInZone = GameObject.FindGameObjectsWithTag("Zone 1");
        for(int i = 0; i < objectsInZone.Length; i++)
        {
            zoneOneMovePoints.Add(objectsInZone[i].transform.position);
        }
        zones.Add(zoneOneMovePoints);

        // fills in the list zoneTwoMovePoints with the transform.position of all objects with the tag "Zone 2"
        objectsInZone = GameObject.FindGameObjectsWithTag("Zone 2");
        for (int i = 0; i < objectsInZone.Length; i++)
        {
            zoneTwoMovePoints.Add(objectsInZone[i].transform.position);
        }
        zones.Add(zoneTwoMovePoints);

        // fills in the list zoneThreeMovePoints with the transform.position of all objects with the tag "Zone 3"
        objectsInZone = GameObject.FindGameObjectsWithTag("Zone 3");
        for (int i = 0; i < objectsInZone.Length; i++)
        {
            zoneThreeMovePoints.Add(objectsInZone[i].transform.position);
        }
        zones.Add(zoneThreeMovePoints);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function for the PlayerController script to access the zone list, returns the nested list zones
    public static List<List<Vector2>> GetZoneList()
    {
        return zones;
    }

}
