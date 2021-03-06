using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    public float frameRate;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }
}
