using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodInteraction : MonoBehaviour
{
    public float ModifySize;

    private void OnTriggerEnter(Collider player)
    {
        if (ReferenceEquals(player.gameObject, GameManager.Instance.player))
        {
            // Disable current Object
            // Increase the current object's size by 1.5
            // Increase object's position for it to not clip
            // Disable objects
            // Add objects to destroy stack
            //other.gameObject.SetActive(false);
            //GameObjectPool.Push(other.gameObject);
            player.gameObject.GetComponent<Player>().Grow(ModifySize);
            Destroy(gameObject);
        }
    }
}
