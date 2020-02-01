using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BurgerType { good, small, hight, longer, divide}
public class Script_Burger : MonoBehaviour
{
    public BurgerType type;
    public float moveSpeed;
    public int scoreValue = 15 ;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Move(Vector3.right,moveSpeed);
    }

    void Move(Vector3 _direction,float _moveSpeed)
    {
        rb.velocity = _direction * _moveSpeed;
    }
}
