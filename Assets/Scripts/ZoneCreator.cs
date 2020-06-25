using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCreator : MonoBehaviour
{   // Will create zones by seraching for game objects with tags, the tags determine what zone the object goes into. The game object gives its vector2 transform and stores it in its respective zone
    #region Public Vars
    public List<List<Vector2>> zones = new List<List<Vector2>>();
    public List<Vector2> zoneMovePoints = new List<Vector2>();
    #endregion

    #region Private Vars

    #endregion

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

    }

}
