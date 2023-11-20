using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float flySpeed = 10f;

    private Vector3 flyDirection;

    public void SetDirection(Vector2 direction)
    {
        flyDirection = direction;
    }

    void Update()
    {
        transform.position += flyDirection * Time.deltaTime * flySpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
