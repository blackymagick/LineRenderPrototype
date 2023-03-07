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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //audioSource.PlayOneShot(SFXBounce);
        //_contact = true;
        playerM._canMove = false;
        var offset = transform.position - collision.gameObject.transform.position;
        playerM.rotation = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, playerM.rotation);

        //VFXClink.Play();
        StartCoroutine(dazedTime());
    }

    

    IEnumerator dazedTime()
    {
        yield return new WaitForSeconds(waitTime);
        playerM._canMove = true;
        //_contact = false;
    }
}
