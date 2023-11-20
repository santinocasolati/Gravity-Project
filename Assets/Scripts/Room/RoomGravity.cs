using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGravity : MonoBehaviour
{
    public Transform gravityRotate;

    private int state = 0;
    private bool gravityChanged = false;

    void Update()
    {
        float btn = Input.GetAxisRaw("Fire2");

        if (btn == 1)
        {
            if (!gravityChanged)
            {
                gravityChanged = true;

                ChangeGravity();
            }
        } else if (btn == 0)
        {
            gravityChanged = false;
        }
    }

    void ChangeGravity()
    {
        state++;

        if (state == 4)
        {
            state = 0;
        }

        Vector2 g = new Vector2();

        switch (state)
        {
            case 0:
                g.x = 0;
                g.y = -9.81f;
                PlayerManager.instance.SetDirections(Vector2.right, Vector2.up);
                break;

            case 1:
                g.x = 9.81f;
                g.y = 0;
                PlayerManager.instance.SetDirections(Vector2.up, -Vector2.right);
                break;

            case 2:
                g.x = 0;
                g.y = 9.81f;
                PlayerManager.instance.SetDirections(-Vector2.right, -Vector2.up);
                break;

            case 3:
                g.x = -9.81f;
                g.y = 0;
                PlayerManager.instance.SetDirections(-Vector2.up, Vector2.right);
                break;
        }

        Physics2D.gravity = g;
    }
}
