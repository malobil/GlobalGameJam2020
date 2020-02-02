using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AnimationEvents : MonoBehaviour
{
    public AudioSource audioComp;

    public void HideObject(GameObject target)
    {
        target.SetActive(false);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void PlayASound(AudioClip soundToPlay)
    {
        audioComp.PlayOneShot(soundToPlay);
    }
}
