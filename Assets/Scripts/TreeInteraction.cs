using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : MonoBehaviour
{
    private enum States
    {// Potentially add kindled/charred/etc..
        REGULAR,
        FIRE
    }

    private enum Spread
    {// How many trees does a single tree on fire infect
        REGULAR = 1,
        DANGEROUS,
        EXTREME
    }

    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How damaged is the tree? 0==Mint//100==Completely burnt.")]
    private float DescructionLevel;

    [SerializeField] private States InitState = States.REGULAR;
    [SerializeField] private Material InitShade;
    [SerializeField] private Material FireShade;
    [SerializeField] private Material SelectionShade;

    #region Tree Properties

    [SerializeField]
    private TreeWaypoint CurrentTree;

    #endregion Tree Properties

    private void Start()
    {
        CurrentTree = new TreeWaypoint(gameObject);
        // Initialize our TreeMapper, it maps the relations to the trees nearby,
        // distance being the core "relation"
        CurrentTree.TreeMapper();
    }

    private void Update()
    {
        // Keep track of the tree's state. If TreeStates.FIRE, apply the correct
        // shader.
    }

    private void OnTriggerEnter(Collider CollObj)
    {
        // Check which object collides with our tree. If FIRE collides -> put
        // tree on fire. If WATER collides -> extinguish the flames and save the
        // destruction percentage.

        // Tree changes state to burning
        // -+ Flame size?
        if (CollObj.gameObject.tag == "Player") {
            MaterialSwitcher(FireShade);
            InitState = States.FIRE;
        }
    }

    private void FireSpreader()
    {
        // Activates if CurrentTree is on States.FIRE
        // Check if near trees not on fire are within a certain distance [2-8]
            // If true -> change closest state to States.FIRE
            // Add bias to tree distance
    }

    private void MaterialSwitcher(Material mat)
    {
        gameObject.GetComponent<Renderer>().material = mat;
    }


    #region Spreading Research

    private void OnMouseEnter(){}
    private void OnMouseExit(){}
    private void OnMouseDown(){}

    #endregion Spreading Research
}
