using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BurgerDeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Script_Burger>().type != BurgerType.good)
        {
            Script_GameManager.Instance.SubstractLife(1);
        }

        Script_GameManager.Instance.RemoveBurgerFromList(other.gameObject);
        Destroy(other.gameObject);
    }
}
