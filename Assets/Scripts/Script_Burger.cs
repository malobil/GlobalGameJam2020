using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BurgerType { good, small, hight, longer, divide}
public class Script_Burger : MonoBehaviour
{
    public BurgerType type;
    public int scoreValue = 15 ;
    public GameObject associateInputUI;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       Script_UIManager.Instance.UpdateInputIndicationPosition(associateInputUI,Script_GameManager.Instance.GetPercentDistance(transform.position));
    }

    public void Move(Vector3 _direction,float _moveSpeed)
    {
        rb.velocity = _direction * _moveSpeed;
    }

    public void SetAssociateInputUI(GameObject newAssociateInputUI)
    {
        associateInputUI = newAssociateInputUI;
    }

    public void DestroyMe()
    {
        Destroy(associateInputUI);
        Destroy(gameObject);
    }
}
