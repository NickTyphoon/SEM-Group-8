using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0));

        // Clamp the player's position to the specified X-axis bounds
        float clampedX = Mathf.Clamp(transform.position.x, -15f, 15f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
