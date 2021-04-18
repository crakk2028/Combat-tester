using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiMovement : MonoBehaviour
{
    
    float NextXPosition;
    float CurrentXPosition;
    float initialPosition;
    Rigidbody2D rb;
    Transform thePlayer; 

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position.x;
        NextXPosition = Random.Range(initialPosition-5.0f, initialPosition+5.0f);
        rb = GetComponent<Rigidbody2D>();
        //CurrentXPosition = CurrentPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        bool hunting = false;
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log("CurrentPos = " + gameObject.transform.position.x);

        //HuntingMode ?
        if(Mathf.Abs(thePlayer.position.x - gameObject.transform.position.x) < 3.0f) {
            hunting = true;
            NextXPosition = thePlayer.position.x;
            Debug.Log("Hunting" + NextXPosition);
        } else {
            hunting = false;
        }
        if(Movement(NextXPosition, hunting)) {
            if(!hunting) {
                NextXPosition = Random.Range(initialPosition-5.0f, initialPosition+5.0f);
            }
        }
        //Debug.Log("CurrentXposition=" + CurrentXposition);
    }

    bool Movement(float TargetPosition, bool hunting){
        bool dest = false;
        float velocity = 1.0f;
        float CurrentXPosition = gameObject.transform.position.x;
        dest = false;
        if(hunting) {
            velocity += 1.0f;
        }
        Vector2 targetVelocity;
        if((TargetPosition - CurrentXPosition) > 0.5) {
            targetVelocity = new Vector2(velocity, 0);
        } else if((TargetPosition - CurrentXPosition) < -0.5) {
            targetVelocity = new Vector2(velocity * (-1), 0);
        } else {
            dest = true;
            targetVelocity = new Vector2(0, 0);
        }
        rb.velocity = targetVelocity;
        return dest;
    }
}
