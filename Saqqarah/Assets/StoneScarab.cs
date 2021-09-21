using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScarab : MonoBehaviour
{
    public GameObject blueScarab;
    public GameObject goldenScarab;
    public GameObject goldenScarabCollector;
    public GameObject[] avaiablePaths;

    bool blueAlreadyExist;
    GameObject existingBlue;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        FindGameObjectInChildWithTag(gameObject.transform.parent.gameObject, "Blue Scarab");
        if (!blueAlreadyExist)
        {
            GameObject blue = Instantiate(blueScarab, transform.position, Quaternion.identity, transform.parent) as GameObject;
            FindObjectOfType<BlueScarab>().ReceiveNewPos(transform.position);
            Destroy(this.gameObject);

        }
        else
        {
            for (int i = 0; i < avaiablePaths.Length; i++)
            {
                if (this.gameObject.name == avaiablePaths[i].gameObject.name)
                {
                    Debug.Log("for loop passed");
                    Vector3 currBluePos = FindObjectOfType<BlueScarab>().GiveCurrectPos();
                    GameObject golden = Instantiate(goldenScarab, currBluePos, Quaternion.identity, goldenScarabCollector.transform) as GameObject;
                    FindObjectOfType<BlueScarab>().ReceiveNewPos(transform.position);
                    Destroy(this.gameObject);
                }
            }

        }
        




    }

    public GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                blueAlreadyExist = true;
                existingBlue = t.GetChild(i).gameObject;
            }
            else
            {
                blueAlreadyExist = false;
            }

        }

        return null;
    }

}
