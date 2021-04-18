using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    float movespeed = 5000.0f;
    Rigidbody2D rb;
    
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        Debug.Log(horizontalMovement);
        MovePlayer(horizontalMovement, 0);
    }

void MovePlayer(float _horizontalMovement, float _verticalClimbingMovement)
    {
        Vector3 tagetVelocity = new Vector2(_horizontalMovement, _verticalClimbingMovement); // Ajout du mouvement vertical
        rb.velocity = Vector3.SmoothDamp(rb.velocity, tagetVelocity, ref velocity, .05f);
    }
}
