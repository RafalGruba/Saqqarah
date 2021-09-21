using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fireBall;

    void Update()
    {
        FireBallOnClick();
    }

    private void FireBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(fireBall, transform.position, Quaternion.identity) as GameObject;
            Destroy(projectile, 0.5f);
        }
    }

}
