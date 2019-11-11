using System.Collections;
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
    public float shrinkAmountHazard = 0.5f;

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
        gameObject.transform.localScale = new Vector3(getCurrentSize(), getCurrentSize(), getCurrentSize());
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Constants.TAG_HAZARD)
        {
            Shrink(shrinkAmountHazard);
        }
    }

    public void Grow(float growAmount)
    {
        currentSize += growAmount;
        gameObject.transform.localScale = new Vector3(getCurrentSize(), getCurrentSize(), getCurrentSize());
        currentShrinkTimer = 0;
    }

    private void Shrink(float shrinkAmount)
    {
        if (currentSize > 0 && vulnerable)
        {
            currentSize -= shrinkAmount;
            gameObject.transform.localScale = new Vector3(getCurrentSize(), getCurrentSize(), getCurrentSize());
            currentShrinkTimer = shrinkTimer;
            if (currentSize <= 0)
            {
                //character died, respawn if you have lives (Have to check with tests if it's a good idea to give the character lives)
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
                    StartCoroutine(Blink(3.0f));
                }
            }
        }
    }

    private float getCurrentSize()
    {
        return minimalSizeScale + currentSize / size;
    }

    private IEnumerator Blink(float waitTime)
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
