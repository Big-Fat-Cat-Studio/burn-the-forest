using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodInteraction : MonoBehaviour, IObject
{
    public Vector3 ModifySize { get; set; }

    private void OnTriggerEnter(Collider player)
    {
        // Disable current Object
        // Increase the current object's size by 1.5
        // Increase object's position for it to not clip
        // Disable objects
        // Add objects to destroy stack
        //other.gameObject.SetActive(false);
        //GameObjectPool.Push(other.gameObject);
        Destroy(gameObject);
        player.gameObject.transform.localScale += (ModifySize);
    }
}
