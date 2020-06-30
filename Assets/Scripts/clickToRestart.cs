using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickToRestart : MonoBehaviour
{
    public float waitTime;
    bool canRestart = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToRestart());
    }

    // Update is called once per frame
    void Update()
    {
        if (canRestart && Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator waitToRestart()
    {
        yield return new WaitForSeconds(waitTime);
        canRestart = true;
    }


}
