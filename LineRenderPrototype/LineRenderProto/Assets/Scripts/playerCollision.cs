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
            StartCoroutine(dazedTime());
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            gemManager.Instance.addGem();
            playerM.vfxCollection.Play();
            collision.gameObject.SetActive(false);
        }
    }


    IEnumerator dazedTime()
    {
        playerM.EndMovement();
        yield return new WaitForSeconds(waitTime);
        playerEvents.onDeathAction?.Invoke();
        //_contact = false;
    }
}
