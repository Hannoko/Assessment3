using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] pacmanSprites;
    [SerializeField] private float animationFrameTime;

    private SpriteRenderer spriteRenderer;
    public bool isAnimationActive;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isAnimationActive = true;
        StartCoroutine(AnimatePacman());
    }

    private IEnumerator AnimatePacman()
    {
        int spriteNo = 0;

        while (true)
        {
            if (isAnimationActive)
            {
                spriteRenderer.sprite = pacmanSprites[spriteNo];
                spriteNo = (spriteNo + 1) % pacmanSprites.Length;
            }
            else
            {
                spriteRenderer.sprite = pacmanSprites[1];
            }

            yield return new WaitForSeconds(animationFrameTime);
        }
    }
}
