using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 20f;

    Vector3 pointerPos;

    // Start is called before the first frame update
    void Start()
    {
        pointerPos = FindObjectOfType<MousePosition3D>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = projectileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pointerPos, step);
    }
}
