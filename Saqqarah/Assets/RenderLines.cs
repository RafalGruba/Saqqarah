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
        //Debug.Log(newWaypoint.name);
        //Debug.Log(points.Count);
        //Debug.Log(points.Count - 1);
        //lineRenderer.SetVertexCount(points.Count - 1);
        //lr.SetPosition(points.Count - 1, newWaypoint.transform.position);
    }

    public void SwitchLeadingWaypoint(Transform currentBluePos)
    {
        int lastItem = points.Count - 1;
        points[lastItem] = currentBluePos;
    }
    public void DebugLastItemOnList()
    {
        int lastItem = points.Count - 1;
        points.Remove(points[lastItem]);
    }    

}
