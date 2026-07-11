using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 8;
    public KeyCode InputKeyUp = KeyCode.W;
    public KeyCode InputKeyDown = KeyCode.S;

    private void Update()
    {
        float movement = ProcessInput();
        Move(movement);
        PositionMaxPaddle();
    }

    private float ProcessInput()
    {
        float movement = 0;

        if (Input.GetKey(InputKeyUp))
        {
            movement++;
        }
        if (Input.GetKey(InputKeyDown))
        {
            movement--;
        }

        return movement;
    }

    private void Move(float movement)
    {
        transform.Translate(0, movement * Speed * Time.deltaTime, 0);
    }


    private void PositionMaxPaddle()
    {
        float maxPositionY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float minPositionY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        Vector3 position = transform.position;
        position.y = Math.Clamp(position.y, minPositionY + 1, maxPositionY - 1);
        // if (position.y >= maxPositionY - 1)
        // {
        //     position.y = maxPositionY - 1;
        // }
        // else if (position.y <= minPositionY + 1)
        // {
        //     position.y = minPositionY + 1;
        // }
        transform.position = position;
    }
}
