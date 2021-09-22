using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject fireBallSpawner;

    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        FireBallOnClick();
    }

    private void FireBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("fire shot"); // animation trigger
            GameObject projectile = Instantiate(fireBall, fireBallSpawner.transform.position, Quaternion.identity) as GameObject;
            Destroy(projectile, 0.5f);
        }
    }

}
