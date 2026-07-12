using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 5;
    public Transform PaddleRight;
    public Transform PaddleLeft;
    private Vector2 Direction = Vector2.one;


    private float paddleHeight = 2f;
    private float paddleWidth = 0.3f;
    private float ballSize = 0.3f;

    private void Start()
    {
        RandomDirection();
    }
    private void RandomDirection()
    {
        System.Random random = new();
        int num = random.Next(0, 2);
        if (num % 2 == 0)
        {
            Direction = Vector2.one;
        }
        else
        {
            Direction = -Vector2.one;
        }
    }

    private void Update()
    {
        Move();
        MaxScreenHeight();
        CollisionBallPaddle();
    }


    private void Move()
    {
        Vector3 movement = Direction * Speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void MaxScreenHeight()
    {
        Vector3 position = transform.position;

        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        if (Direction.y > 0 && position.y >= (screenTop - 0.15f))
        {
            Direction.y = -1;
        }
        if (Direction.y < 0 && position.y <= (screenBottom + 0.15f))
        {
            Direction.y = 1;
        }
    }


    private void CollisionBallPaddle()
    {
        if (Direction.x > 0)
        {
            if ((transform.position.x + ballSize / 2f) > (PaddleRight.position.x - paddleWidth / 2f)
            && (transform.position.x + ballSize / 2f) < (PaddleRight.position.x + paddleWidth / 2f)
            && (transform.position.y) > (PaddleRight.position.y - paddleHeight / 2f)
            && (transform.position.y) < (PaddleRight.position.y + paddleHeight / 2f)
            )
            {
                Direction.x = -1;
            }
        }
        else if (Direction.x < 0)
        {
            if ((transform.position.x - ballSize / 2) > (PaddleLeft.position.x - paddleWidth / 2f)
            && (transform.position.x - ballSize / 2f) < (PaddleLeft.position.x + paddleWidth / 2f)
            && (transform.position.y) > (PaddleLeft.position.y - paddleHeight / 2f)
            && (transform.position.y) < (PaddleLeft.position.y + paddleHeight / 2f)
            )
            {
                Direction.x = 1;
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
        Direction = -Direction;

    }

}
