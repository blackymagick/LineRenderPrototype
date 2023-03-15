using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed, tempSpeed, boostSpeed, boostTime, boostCoolDown, turnSpeed, inputX, rotation, rotationSpeed;
    public bool _canMove, _canBoost, _gameStart;
    public ParticleSystem vfxBoostReady, vfxCollection;
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //_canMove = false;
        tempSpeed = speed;
        speed = 0;
        startPosition = transform.position;
        startRotation = transform.rotation;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rotation = inputX * turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotation);

        if (Input.GetKeyUp(KeyCode.Space) && !_canMove && !_gameStart)
        {
            _canMove = true;
            GetComponent<CircleCollider2D>().enabled = true;
            _gameStart = true;
            speed = tempSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && !_canMove)
        {
            _canMove = true;
            speed = tempSpeed;
        }

        if (!_canMove) return;
        
        

        if (Input.GetKeyUp(KeyCode.Space) && _canBoost && _canMove)
        {
            boostCoolDown = 0;
            
            StartCoroutine(speedBoosted());
        }

        if (!_canBoost)
        {
            boostCoolDown += Time.deltaTime;
            if (boostCoolDown >= 5)
            {
                vfxBoostReady.Play();
                _canBoost = true;
            }
        }
    }

    private void FixedUpdate()
    {

        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    public void ResetPosition()
    {
        _gameStart= false;
        transform.position = startPosition;
        transform.rotation = startRotation;
        _canMove = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    public void EndMovement()
    {
        
        speed = 0;
        boostCoolDown = 0;
        _canBoost = false;
    }


    IEnumerator speedBoosted()
    {
        speed = boostSpeed;
        yield return new WaitForSeconds(boostTime);
        speed = tempSpeed;
        _canBoost = false;
        boostCoolDown = 0;
    }

}
