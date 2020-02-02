using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AnimationEvents : MonoBehaviour
{
    public void HideObject(GameObject target)
    {
        target.SetActive(false);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
