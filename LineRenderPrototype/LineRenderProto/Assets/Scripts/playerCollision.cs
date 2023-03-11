using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    private playerMovement playerM;
    private playerEvents playerEvents;
    public float waitTime = 0.8f;

    private void Start()
    {
        playerM = GetComponent<playerMovement>();
        playerEvents = GetComponent<playerEvents>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {

            playerEvents.onDeathAction?.Invoke();
        }
    }



    IEnumerator dazedTime()
    {
        yield return new WaitForSeconds(waitTime);
        playerM._canMove = true;
        //_contact = false;
    }
}
