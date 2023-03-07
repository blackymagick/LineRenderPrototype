using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    private playerMovement playerM;
    public float waitTime = 0.8f;

    private void Start()
    {
        playerM = GetComponent<playerMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            playerM.death();
        }
    }



    IEnumerator dazedTime()
    {
        yield return new WaitForSeconds(waitTime);
        playerM._canMove = true;
        //_contact = false;
    }
}
