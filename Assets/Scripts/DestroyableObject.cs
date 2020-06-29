using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    #region Private Vars

    #endregion

    #region Public Vars
    public float destroyVelocity = 100.0f;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerController.isMoving)
        {
            EnumerateZonePoint();

            collision.gameObject?.GetComponent<PlayerController>().KickEvent.Invoke();
            StartCoroutine(KickOfScreen());
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

    public IEnumerator KickOfScreen()
    {
        yield return new WaitForSeconds(.2f);
        Vector3 dir = transform.position;
        dir.z = 0;
        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = (destroyVelocity * dir);
    }
}
