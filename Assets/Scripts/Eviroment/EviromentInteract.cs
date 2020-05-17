using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EviromentInteract : MonoBehaviour
{
   private Animator anim;

    void OnEnable()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(AnimSetter());
        } 
    }
    IEnumerator AnimSetter()
    {
        anim.SetBool("interact", true);
        yield return new WaitForSeconds(.2f);
        anim.SetBool("interact", false);
    }
}
