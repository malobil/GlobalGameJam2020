﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BurgerType { good, small, hight, longer, divide}
public class Script_Burger : MonoBehaviour
{
    public BurgerType type;
    public int scoreValue = 15 ;
    public SpriteRenderer inputIndication;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _direction,float _moveSpeed)
    {
        rb.velocity = _direction * _moveSpeed;
    }

    public void SetupInputIndication(Sprite inputSpr)
    {
        inputIndication.sprite = inputSpr;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
