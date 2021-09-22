using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScarab : MonoBehaviour
{
    [SerializeField] private float scarabSpeed = 3f;

    private bool blueIsMoving = false;
    private void Update()
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

    public bool IsBlueMoving()
    {
        return blueIsMoving;
    }

}
