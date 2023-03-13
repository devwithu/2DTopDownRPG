using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Chest : Collectable
{
    [FormerlySerializedAs("emptychest")] public Sprite emptyChest;
    public int pesosAmount = 5;
    
    protected override void OnCollide(Collider2D col)
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>()
                .sprite = emptyChest;
            
        }
    }
}