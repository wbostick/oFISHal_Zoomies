﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    #region Private Vars
    private bool isDestroyed = false;
    private bool targetChanged = false;
    #endregion

    #region Public Vars

    #endregion

    void LateUpdate()
    {
        if (isDestroyed && !targetChanged)
        {
            PlayerController.ChangeTargetPoint();
            targetChanged = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnumerateZonePoint();
            isDestroyed = true;
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
