using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float forceX;
    Rigidbody2D playerRigidbody2D;
    float toleft = -1;
    float toright = 1;
    float stop = 0;
    float directionX;
    public static bool isdead;
    void Start()
    {
        isdead = false;
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            directionX = toleft;
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            directionX = toright;
        }
        else{
            directionX = stop;
        }
        Vector2 newDirection = new Vector2(directionX, 0);
        playerRigidbody2D.AddForce(newDirection*forceX);
    }
}
