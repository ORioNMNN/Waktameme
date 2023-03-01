using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Vector2 StartPosition;
    private Vector2 EndPosition;

    private Movement2D movement2D;

    private int type;


    void Start()
    {
        StartPosition = new Vector2 (transform.position.x, transform.position.y);
        movement2D = GetComponent<Movement2D>();
        type = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;

        if (type == 1)
        {
            movement2D.MoveTo(new Vector2(0, -1));
        }

            if (transform.position.y <= -3.3f)
        {
            type = 0;
            movement2D.MoveTo(new Vector2(0, 1));
           
        }

        if (transform.position.y >= 5.2002f && type == 0)
        {
            type = 2;
            movement2D.MoveTo(new Vector2(0, 0));
        }
    }
}
