using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScarab : MonoBehaviour
{
    [SerializeField] private float scarabSpeed = 3f;

    private bool blueIsMoving = false;
    private void Update()
    {
        MoveToParent();
    }

    public bool IsBlueMoving()
    {
        return blueIsMoving;
    }

    private void MoveToParent()
    {
        if (transform.position != transform.parent.transform.position)
        {
            float step = scarabSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.transform.position, step);
            blueIsMoving = true;
        }
        else
        {
            blueIsMoving = false;
        }
    }
}
