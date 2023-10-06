using UnityEngine;

public class Pacman : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 direction;
    private Vector2 nextDirection;
    private bool isMoving;
    private PacmanAnimation pacmanAnimation;

    private void Start()
    {
        pacmanAnimation = GetComponent<PacmanAnimation>();
        direction = Vector2.right;
        nextDirection = Vector2.right;
        isMoving = false;
    }

    private void Update()
    {
        HandleInput();
        MovePacman();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetNextDirection(Vector2.up);
            isMoving = true;  
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetNextDirection(Vector2.down);
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetNextDirection(Vector2.left);
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetNextDirection(Vector2.right);
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) ||
            Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMoving = false;
        }
    }

    private void MovePacman()
    {
        if (isMoving)
        {
            pacmanAnimation.isAnimationActive = true;
            direction = nextDirection;
            Vector3 translation = speed * Time.deltaTime * (Vector3)direction;
            transform.Translate(translation, Space.World);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            pacmanAnimation.isAnimationActive = false;
        }
    }

    private void SetNextDirection(Vector2 newDirection)
    {
        nextDirection = newDirection;
    }
}
