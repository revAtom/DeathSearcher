using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EviromentInteract : MonoBehaviour
{
   private Animator anim;

     void OnTriggerEnter2D(Collider2D collision)
    {
     anim = collision.gameObject.GetComponent<Animator>();

       if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("interact", true);
        } 
    }
}
