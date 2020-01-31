using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BurgerType { good, small, hight, longer}
public class Script_Burger : MonoBehaviour
{
    public BurgerType type;
    public float moveSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Move(Vector3.right,moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(Vector3 _direction,float _moveSpeed)
    {
        rb.velocity = _direction * _moveSpeed;
    }
}
