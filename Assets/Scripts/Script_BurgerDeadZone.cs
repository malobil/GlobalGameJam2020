using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BurgerDeadZone : MonoBehaviour
{
    public GameObject laser;
    public AudioSource audioComp;
    public AudioClip laserSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Script_Burger>().type != BurgerType.good)
        {
            Script_GameManager.Instance.SubstractLife(1);
            Script_GameManager.Instance.RemoveBurgerFromList(other.gameObject);
            other.gameObject.GetComponentInParent<Script_Burger>().DestroyMe();
            laser.SetActive(true);
            audioComp.PlayOneShot(laserSound);
            StartCoroutine(WaitToUnshowLaser());
        }
    }

    IEnumerator WaitToUnshowLaser()
    {
        yield return new WaitForSeconds(0.2f);
        laser.SetActive(false);
    }
}
