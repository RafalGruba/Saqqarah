using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScarab : MonoBehaviour
{
    [SerializeField] private float scarabSpeed = 3f;

    Vector3 newPos;

    private void Update()
    {
        if (transform.position != transform.parent.transform.position)
        {
            float step = scarabSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.transform.position, step);
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
