using UnityEngine;
using System.Collections.Generic;

public class TreeWaypoint
{
    private GameObject TreeContainer;

    public GameObject Tree { get; private set; }
    public SortedDictionary<float, Dictionary<int, GameObject>> TreeRelations { get; private set; }

    public TreeWaypoint(GameObject t) { this.Tree = t; }

    public void TreeMapper()
    {
        // Grab all trees in the scene
        TreeContainer = GameObject.Find("Trees");
        Dictionary<float, Dictionary<int, GameObject>> tempDict = new Dictionary<float, Dictionary<int, GameObject>>();

        foreach(Transform child in TreeContainer.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.GetInstanceID() != Tree.GetInstanceID() &&
                child.gameObject.GetInstanceID() != TreeContainer.GetInstanceID())
            {
                // Calculate distance between this tree and the current
                tempDict.Add(
                    Vector3.Distance(child.transform.position, Tree.transform.position),
                    new Dictionary<int, GameObject>() { { child.gameObject.GetInstanceID(), child.gameObject } }
                    );
            }
        }

        // Sort them into TreeRelations
        TreeRelations = new SortedDictionary<float, Dictionary<int, GameObject>>(tempDict);

        Debug.Log(Tree.GetInstanceID());
    }
}
