using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed, turnSpeed, inputX, rotation;
    public bool _canMove;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //_canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _canMove = true;
        }

        if(_canMove)
        inputX = Input.GetAxisRaw("Horizontal");
        rotation = inputX * turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void FixedUpdate()
    {

        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    public void death()
    {
        _canMove = false;
        speed = 0;
    }


}