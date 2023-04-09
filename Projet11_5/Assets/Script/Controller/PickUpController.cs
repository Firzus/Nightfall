using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //public ProjectileGun gunScript;

    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForewardForce, dropUpwardForce;

    public bool isEquipped;
    public static bool isSlootFull;

    void Update()
    {
        // Range for E
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!isEquipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !isSlootFull)
        {
            PickUp();
        }

        // Drop
        if(isEquipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        isEquipped= true;
        isSlootFull= true;

        rb.isKinematic = true;
        coll.isTrigger = true;

        //gunScript.enabled = true;
    }

    private void Drop()
    {
        isEquipped = false;
        isSlootFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        //gunScript.enabled = false;
    }
}
