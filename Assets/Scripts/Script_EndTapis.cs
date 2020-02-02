using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EndTapis : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Script_Burger>())
        {
            Script_GameManager.Instance.RemoveBurgerFromList(other.gameObject);
            other.gameObject.GetComponentInParent<Script_Burger>().DestroyMe();
        }
    }
}
