using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opacityOnContact : MonoBehaviour
{
    SpriteRenderer sprite;
    public float opacity;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sprite.color = new Color(1f, 1f, 1f, opacity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
