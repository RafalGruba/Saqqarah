using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLines : MonoBehaviour
{
    [SerializeField] private LineController line;
    public List<Transform> points = new List<Transform>();

    private void Update()
    {
        line.SetUpLine(points);
    }

    public void AddLineWaypoint(Transform newWaypoint)
    {
        points.Add(newWaypoint);
    }
}
