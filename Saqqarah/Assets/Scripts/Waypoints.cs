using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<GameObject> availablePathss = new List<GameObject>();
    public GameObject blueScarab;
    public GameObject goldenScarab;
    public GameObject stoneScarab;

    bool blueAlreadyExist;
    //bool didIWin = false;
    GameObject existingBlue;
    List<GameObject> whereCanBlueGo;
    RenderLines rl;
    LineController lc;
    Pedestal pdstl;

    private void Start()
    {
        rl = FindObjectOfType<RenderLines>();
        lc = FindObjectOfType<LineController>();
        pdstl = FindObjectOfType<Pedestal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        FindGameObjectInChildWithTag(gameObject.transform.parent.gameObject, "Blue Scarab"); // check if under specific wall Blue Scarab already exist
        if (!blueAlreadyExist) // if blue scarab doesn't exist
        {
            GameObject blue = Instantiate(blueScarab, transform.position, Quaternion.identity, transform) as GameObject;
            Destroy(stoneScarab);
            goldenScarab.SetActive(true);
            rl.AddLineWaypoint(this.gameObject.transform); // add new waypoint to Line Renderer
        }
        else // if blue scarab does exist
        {
            if (!existingBlue.GetComponent<BlueScarab>().IsBlueMoving()) // pass if blue isn't moving
            {
                for (int i = 0; i <= whereCanBlueGo.Count - 1; i++)
                {
                    if (this.gameObject.name == whereCanBlueGo[i].gameObject.name) // check if Waypoint that was hit is on the array of avaiable paths for Blue Scarab by comparing Waypoint names
                    {
                        RemovePath(existingBlue.transform.parent.name); // remove possibility going from B to A
                        whereCanBlueGo.Remove(whereCanBlueGo[i]); // remove possibility going from A to B
                        Destroy(stoneScarab); 
                        goldenScarab.SetActive(true);
                        rl.AddLineWaypoint(this.gameObject.transform); // add new waypoint to Line Renderer
                        existingBlue.transform.SetParent(this.gameObject.transform, true); // set new parent of Blue Scarab (this.gameObject), (Blue Scarab will move by itself to new parent using BlueScarab.cs)
                        if (lc.DidIWin())
                        {
                            pdstl.IWin();
                        } // win reward
                        return; // no point to go further
                    }
                }
            }
        }
    }

    private void RemovePath(string whereBlueCameFrom)
    {
        for (int j = 0; j <= availablePathss.Count - 1; j++) 
        {
            if (availablePathss[j].gameObject.name == whereBlueCameFrom)
            {
                availablePathss.Remove(availablePathss[j]);
            }
        }
    } // remove possibility going from B to A

    public List<GameObject> PassList()
    {
        whereCanBlueGo = availablePathss;
        return whereCanBlueGo;
    } // passing the list

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
                    whereCanBlueGo = existingBlue.transform.parent.gameObject.GetComponent<Waypoints>().PassList();
                    return null;
                }
                else
                {
                    blueAlreadyExist = false;
                }
            }


        }

        return null;
    } // find a child of 2nd instantion under game object "Wall"

}
