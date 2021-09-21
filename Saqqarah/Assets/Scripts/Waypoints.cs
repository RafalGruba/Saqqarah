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
            //FindObjectOfType<BlueScarab>().ReceiveNewPos(transform.position);
            Destroy(stoneScarab);
            goldenScarab.SetActive(true);
        }
        else
        {
            for (int i = 0; i < whereCanBlueGo.Length; i++)
            {
                if (this.gameObject.name == whereCanBlueGo[i].gameObject.name) // check if Waypoint that was hit is on the array of avaiable paths for Blue Scarab by comparing Waypoint names
                {
                    Destroy(stoneScarab);
                    goldenScarab.SetActive(true);
                    Debug.Log("i have a match");
                    existingBlue.transform.SetParent(this.gameObject.transform, true); // set new parent of Blue Scarab (this.gameObject), (Blue Scarab will move by itself to new parent using BlueScarab.cs)
                    return;
                }
                else
                {
                    Debug.Log("i dont have a match");
                }
                

            }

        }
    }

    public GameObject[] PassAnArray()
    {
        whereCanBlueGo = avaiablePaths;
        return whereCanBlueGo;
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