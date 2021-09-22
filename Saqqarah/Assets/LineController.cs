using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private List<Transform> points = new List<Transform>();


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(List<Transform> points)
    {
        lr.positionCount = points.Count;
        this.points = points;
    }

    private void Update()
    {
        for (int i = 0; i <= points.Count - 1; i++)
        {
            lr.SetPosition(i, new Vector3(points[i].position.x, points[i].position.y, -0.15f));
        }
    }

}
