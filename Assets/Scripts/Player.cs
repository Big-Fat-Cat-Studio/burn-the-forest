﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text livesText;
    public int amountOfLives = 3;

    public float size = 100.0f;
    public float shrinkTimer = 5.0f;
    public float shrinkAmountIdle = 0.05f;

    [Header("Minimal Size Scale: Not the same as the size we use in game, use the scale in the Unity inspector to check which number you want")]
    [Tooltip("Not the same as the size we use in game, use the scale in the Unity inspector to check which number you want")]
    public float minimalSizeScale = 0.25f;

    private float currentSize;
    private float currentShrinkTimer = 0f;
    private bool vulnerable = true;

    // Start is called before the first frame update
    void Start()
    {
        currentSize = size;
        gameObject.transform.localScale = getCurrentSize();
        livesText.text = "Lives: " + amountOfLives;
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

    /**
     * Grows the character.
     */
    public void Grow(float growAmount)
    {
        currentSize += growAmount;
        gameObject.transform.localScale = getCurrentSize();
        currentShrinkTimer = 0;
    }

    /**
     * Shrinks the character. Kills the character if their size is 0.
     */
    public void Shrink(float shrinkAmount)
    {
        if (currentSize > 0 && vulnerable)
        {
            currentSize -= shrinkAmount;
            gameObject.transform.localScale = getCurrentSize();
            currentShrinkTimer = shrinkTimer;
            if (currentSize <= 0)
            {
                dead();
            }
        }
    }

    /**
     * Player died, respawn player if you have lives
     */
    private void dead()
    {
        amountOfLives -= 1;
        livesText.text = "Lives: " + amountOfLives;
        if (amountOfLives <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Grow(size);
            vulnerable = false;
            StartCoroutine(InvulnerableBlink(3.0f));
        }
    }

    /**
     * Gets the size of the character.
     */
    private Vector3 getCurrentSize()
    {
        return new Vector3(minimalSizeScale + currentSize / size, 
            minimalSizeScale + currentSize / size, 
            minimalSizeScale + currentSize / size);
    }

    /**
     * Gives the character a blinking effect, to show that it's invulnerable.
     */
    private IEnumerator InvulnerableBlink(float waitTime)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        var endTime = Time.time + waitTime;
        while (Time.time < endTime)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        vulnerable = true;
    }
}
