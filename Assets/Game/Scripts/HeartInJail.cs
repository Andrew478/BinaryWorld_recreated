using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartInJail : MonoBehaviour
{
    public Sprite heartState_inJail;
    public Sprite heartState_free;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = heartState_inJail;
    }

}
