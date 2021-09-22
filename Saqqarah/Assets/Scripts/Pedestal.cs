using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    private bool iWin = false;
    [SerializeField] private Transform newPos;
    private float pedestalSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (iWin && transform.position != newPos.position)
        {
            float step = pedestalSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, newPos.position, step);
        }
    }

    public void IWin()
    {
        iWin = true;
    }
}
