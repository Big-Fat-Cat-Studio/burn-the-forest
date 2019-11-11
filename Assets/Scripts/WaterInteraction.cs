using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    public float ModifySize;

    private void OnTriggerStay(Collider player)
    {
        if (ReferenceEquals(player.gameObject, GameManager.Instance.player))
        {
            player.gameObject.GetComponent<Player>().Shrink(ModifySize);
        }
    }
}
