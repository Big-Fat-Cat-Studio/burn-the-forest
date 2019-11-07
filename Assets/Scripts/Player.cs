using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float size = 100.0f;
    public float shrinkTimer = 5.0f;
    public float shrinkAmountIdle = 0.05f;
    public float shrinkAmountHazard = 0.5f;

    [Header("Not the same as the size we use in game, use the scale in the Unity inspector to check which number you want")]
    [Tooltip("Not the same as the size we use in game, use the scale in the Unity inspector to check which number you want")]
    public float minimalSizeScale = 0.25f;

    private float currentSize;
    private float currentShrinkTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentSize = size;
        gameObject.transform.localScale = new Vector3(getCurrentSize(), getCurrentSize(), getCurrentSize());
    }

    // Update is called once per frame
    void Update()
    {
        currentShrinkTimer += Time.deltaTime;

        if (currentShrinkTimer >= shrinkTimer)
        {
            Shrink(shrinkAmountIdle);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Constants.TAG_HAZARD)
        {
            Shrink(shrinkAmountHazard);
        }
    }

    public void Grow(float growAmount)
    {
        if (currentSize > 0)
        {
            currentSize += growAmount;
            gameObject.transform.localScale = new Vector3(getCurrentSize(), getCurrentSize(), getCurrentSize());
            currentShrinkTimer = 0;
        }
    }

    private void Shrink(float shrinkAmount)
    {
        if (currentSize > 0)
        {
            currentSize -= shrinkAmount;
            gameObject.transform.localScale = new Vector3(getCurrentSize(), getCurrentSize(), getCurrentSize());
            currentShrinkTimer = shrinkTimer;
        }
        else
        {
            print("dead");
        }
    }

    private float getCurrentSize()
    {
        return minimalSizeScale + currentSize / size;
    }
}
