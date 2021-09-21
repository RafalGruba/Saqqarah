using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] avaiablePaths;
    public GameObject blueScarab;
    public GameObject goldenScarab;
    public GameObject stoneScarab;

    bool blueAlreadyExist;
    GameObject existingBlue;
    GameObject[] whereCanBlueGo;

    private void OnTriggerEnter(Collider other)
    {
        FindGameObjectInChildWithTag(gameObject.transform.parent.gameObject, "Blue Scarab");
        if (!blueAlreadyExist)
        {
            GameObject blue = Instantiate(blueScarab, transform.position, Quaternion.identity, transform) as GameObject;
            FindObjectOfType<BlueScarab>().ReceiveNewPos(transform.position);
            Destroy(stoneScarab);
            goldenScarab.SetActive(true);
        }
        else
        {
            for (int i = 0; i < avaiablePaths.Length; i++)
            {
                // check if (for loop) any object in avaiablePaths has the same name as current parent of Blue Scarab
                if (avaiablePaths[i].gameObject.name == whereCanBlueGo[i].gameObject.name)
                {
                    Debug.Log("i have a match");
                    return;
                }
                else
                {
                    Debug.Log("i dont have a match");
                    Debug.Log("where can blue go " + whereCanBlueGo[i].gameObject.name);
                    Debug.Log("avaiable path from object hit " + avaiablePaths[i].gameObject.name);
                }
                // set new parent of Blue Scarab (this.gameObject), (Blue Scarab will move by itself to new parent using BlueScarab.cs)

            }

        }
    }

    public GameObject[] PassAnArray()
    {
        return avaiablePaths;
    }

    public GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            for (int j = 0; j < t.GetChild(i).childCount; j++)
            {
                if (t.GetChild(i).GetChild(j).gameObject.tag == tag)
                {
                    blueAlreadyExist = true;
                    existingBlue = t.GetChild(i).GetChild(j).gameObject;
                    whereCanBlueGo = existingBlue.transform.parent.gameObject.GetComponent<Waypoints>().PassAnArray();
                    return null;
                }
                else
                {
                    blueAlreadyExist = false;
                }
            }


        }

        return null;
    }

}
