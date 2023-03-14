using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    
    protected override void OnCollide(Collider2D col)
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>()
                .sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmount + "pesos!"
            ,25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}