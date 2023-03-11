using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed, tempSpeed, boostSpeed, boostTime, boostCoolDown, turnSpeed, inputX, rotation;
    public bool _canMove;
    public bool _canBoost;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //_canMove = false;
        tempSpeed = speed;
        speed = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && !_canMove)
        {
            _canMove = true;
            _canBoost = true;
            speed = tempSpeed;
        }

        if(_canMove)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            rotation = inputX * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotation);

            if (Input.GetKeyUp(KeyCode.Space) && _canBoost && _canMove)
            {
                boostCoolDown = 0;
                _canBoost = false;
                StartCoroutine(speedBoosted());
            }

            if (!_canBoost)
            {
                boostCoolDown += Time.deltaTime;
                if (boostCoolDown >= 5)
                {
                    _canBoost = true;
                }
            }
        }
        


        
    }

    private void FixedUpdate()
    {

        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    public void death()
    {
        _canMove = false;
        speed = 0;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }


    IEnumerator speedBoosted()
    {
        speed = boostSpeed;
        yield return new WaitForSeconds(boostTime);
        speed = tempSpeed;
    }

}
