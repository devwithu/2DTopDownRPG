using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;
    public float triggerLength = 1;
    public float chaseLength = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();

        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    protected void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                chasing = true;
           
            Debug.Log(chasing);
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    Debug.Log("0");
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                Debug.Log("1");
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }
            
            hits[i] = null;
            
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experiense += xpValue;
        GameManager.instance.ShowText("+" + xpValue + "xp",
            30,Color.magenta, transform.position, Vector3.up*40, 1.0f);

    }
}
