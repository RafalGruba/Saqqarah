using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScarab : MonoBehaviour
{
    [SerializeField] private float scarabSpeed = 3f;

    Vector3 newPos;

    private void Update()
    {
        if (transform.position != newPos)
        {
            float step = scarabSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, newPos, step);
        }
    }

    public void ReceiveNewPos(Vector3 newPosition)
    {
        newPos = newPosition;
    }

    public Vector3 GiveCurrectPos()
    {
        return transform.position;
    }

}
