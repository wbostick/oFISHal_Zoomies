using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    #region Private Vars

    #endregion

    #region Public Vars
    public bool isDestroyed = false;
    public float destroyVelocity = 100.0f;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerController.isMoving)
        {
            isDestroyed = true;
            EnumerateZonePoint();
            PlayerController.TargetChange();
        }
    }

    private void EnumerateZonePoint()
    {
        if (PlayerController.zoneNumPublic == 0)
        {
            if (PlayerController.zoneOneNumerator < ZoneCreator.zoneOneMaxPoints - 1)
            {
                PlayerController.zoneOneNumerator++;
            }
            else if (PlayerController.zoneOneNumerator < ZoneCreator.zoneOneMaxPoints && isDestroyed)
            {
                PlayerController.CallNextZone();
                PlayerController.isReturning = true;
                PlayerController.isMoving = false;
            }
        }
        else if (PlayerController.zoneNumPublic == 1)
        {
            if (PlayerController.zoneTwoNumerator < ZoneCreator.zoneTwoMaxPoints - 1)
            {
                PlayerController.zoneTwoNumerator++;
            }
            else if (PlayerController.zoneTwoNumerator < ZoneCreator.zoneTwoMaxPoints && isDestroyed)
            {
                PlayerController.CallNextZone();
                PlayerController.isReturning = true;
                PlayerController.isMoving = false;
            }
        }
        else if (PlayerController.zoneNumPublic == 2)
        {
            if (PlayerController.zoneThreeNumerator < ZoneCreator.zoneThreeMaxPoints - 1)
            {
                PlayerController.zoneThreeNumerator++;
            }
            else if (PlayerController.zoneThreeNumerator < ZoneCreator.zoneThreeMaxPoints && isDestroyed)
            {
                PlayerController.CallNextZone();
                PlayerController.isReturning = true;
                PlayerController.isMoving = false;
            }
        }
    }

    public IEnumerator KickOfScreen()
    {
        yield return new WaitForSeconds(.2f);
        Vector3 dir = transform.position;
        dir.z = 0;
        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = (destroyVelocity * dir);
    }
}
