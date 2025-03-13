using UnityEngine;
using System.Collections;

public enum Direction
{
    Left,
    Right
}

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Animator playerAnimator;
    private RectTransform playerRect;
    private bool isPlayerMoving = false;

    private int playerJumpDistance = 150;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        playerRect = player.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: completely disable player movement and only use this for animations. We keep this
        // for debug purposes, so I can fix the animation.
        // NOTE: While the player is jumping, we suppress all other inputs.
        if (isPlayerMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MovePlayer(playerRect, Direction.Left, playerJumpDistance);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayer(playerRect, Direction.Right, playerJumpDistance);
        }
    }

    void MovePlayer(RectTransform rect, Direction direction, int distance)
    {
        isPlayerMoving = true;

        FlipPlayer(rect, direction == Direction.Right);
        Vector2 delta = direction == Direction.Right ? Vector2.right : Vector2.left;

        playerAnimator.SetTrigger("jump");
        StartCoroutine(MovePlayerDiscretized(delta * distance, rect, 0.25f, 5));
    }

    void FlipPlayer(RectTransform rect, bool isFlipped)
    {
        Vector3 scale = rect.localScale;
        scale.x = Mathf.Abs(scale.x) * (isFlipped ? -1 : 1);
        rect.localScale = scale;
    }

    IEnumerator MovePlayerDiscretized(Vector2 delta, RectTransform rect, float duration, int steps = 10)
    {
        Vector2 start = rect.anchoredPosition;
        Vector2 target = start + delta;
        float stepDuration = duration / steps;

        for (int i = 0; i <= steps; i++)
        {
            float t = (float)i / steps; // Discrete step progress
            rect.anchoredPosition = Vector2.Lerp(start, target, t);
            yield return new WaitForSeconds(stepDuration);
        }
        // Ensure final positions are exact.
        rect.anchoredPosition = target;

        // yield return new WaitForSeconds(2 * stepDuration);
        isPlayerMoving = false;
    }
}
