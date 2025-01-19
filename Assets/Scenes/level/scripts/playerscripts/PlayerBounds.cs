using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    public BoxCollider2D Bounds;
    public Vector2 gridMin = new Vector2(-2.5f, -2.5f);
    public Vector2 gridMax = new Vector2(2.5f, 2.5f);

    private BoxCollider2D _boxCollider;

    public void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, gridMin.x, gridMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, gridMin.y, gridMax.y);

        transform.position = newPosition;
    }
}
