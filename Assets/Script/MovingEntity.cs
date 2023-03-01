using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class MovingEntity : MonoBehaviour
{
    private Movement2D   movement2D;
    private Vector3      originPosition;
    private Vector3      originDirection;


    private void Awake()
    {
        movement2D          = GetComponent<Movement2D>();
        originPosition      = transform.position;
        originDirection     = movement2D.MoveDirection;

    }

    private void Reset()
    {
        movement2D.MoveTo(originDirection);
        transform.position = originPosition;
    }


}
