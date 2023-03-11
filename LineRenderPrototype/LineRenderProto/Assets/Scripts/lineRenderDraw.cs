using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class lineRenderDraw : MonoBehaviour
{
    LineRenderer linerenderer = new LineRenderer();
    EdgeCollider2D edgecollider = new EdgeCollider2D();
    public int count;
    public List<Vector2> pointsList;
    public float padding = .1f;
    public Transform headList;
    public bool noLine;

    // Start is called before the first frame update
    void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        edgecollider = GetComponent<EdgeCollider2D>();
        pointsList = new List<Vector2>();
        spawnPoint();
        noLine = true;
        linerenderer.useWorldSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(noLine)
        if (Vector3.Distance(pointsList.Last(), headList.position) > padding)
        {
            spawnPoint();
        }
    }

    void spawnPoint()
    {
        if (pointsList.Count > 1)
        {
            edgecollider.points = pointsList.ToArray<Vector2>();
        }

        pointsList.Add(headList.position);
        linerenderer.positionCount = pointsList.Count;
        linerenderer.SetPosition(pointsList.Count - 1, headList.position);
    }


    public void clearPoints()
    {
        pointsList.Clear();
        linerenderer.positionCount = 0;
        spawnPoint();
        noLine = true;

    }

    IEnumerator removePoints()
    {
        noLine = false;
        while (1 < pointsList.Count)
        {
            
            pointsList.RemoveAt(0);
            linerenderer.positionCount = pointsList.Count;
            yield return new WaitForSeconds(0.1f);
            linerenderer.SetPosition(pointsList.Count-1, headList.position);
            
            
        }
       
    }

} 

