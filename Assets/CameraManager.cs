using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float downspeed=0;
    public float count = 0;
    public Transform player;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(0, -downspeed * Time.deltaTime, 0);
        downspeed = Mathf.Floor((Mathf.Abs(player.transform.position.y))/30)+1;
        
    }
}
