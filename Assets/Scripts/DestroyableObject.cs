using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    #region Private Vars

    #endregion

    #region Public Vars

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerController.isMoving)
        {
            EnumerateZonePoint();
        }
    }

    private void EnumerateZonePoint()
    {
        if (PlayerController.zoneNumPublic == 0 && PlayerController.zoneOneNumerator < ZoneCreator.zoneOneMaxPoints - 1)
        {
            PlayerController.zoneOneNumerator++;
        }
        else if (PlayerController.zoneNumPublic == 1 && PlayerController.zoneTwoNumerator < ZoneCreator.zoneTwoMaxPoints - 1)
        {
            PlayerController.zoneTwoNumerator++;
        }
        else if (PlayerController.zoneNumPublic == 2 && PlayerController.zoneThreeNumerator < ZoneCreator.zoneThreeMaxPoints - 1)
        {
            PlayerController.zoneThreeNumerator++;
        }
    }
}
