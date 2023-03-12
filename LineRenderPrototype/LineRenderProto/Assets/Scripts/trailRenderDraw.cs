using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailRenderDraw : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's transform

    private TrailRenderer trail;
    private EdgeCollider2D col;
    public Vector3 offset;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        col = gameObject.AddComponent<EdgeCollider2D>();
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position + offset;

        Vector2[] points = new Vector2[trail.positionCount];
        for (int i = 0; i < trail.positionCount; i++)
        {
            points[i] = transform.InverseTransformPoint(trail.GetPosition(i));
        }
        col.points = points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

           // GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().death();
        }
    }
}
