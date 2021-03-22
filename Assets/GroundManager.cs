using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundManager : MonoBehaviour
{
    float leftedge = -3;
    float rightedge = 3;
    float initPositionY = 0;
    int MAXGroundCount = 10;
    int MINGroundCountUnderPlayer = 3;
    static int groundNumber = -1;
    public Transform player;
    public List<Transform> grounds;
    [Range(2, 6)] public float spacingY;
    [Range(1, 20)] public float singleFloorHeight;
    public Text displayCountFloor;
    void Start(){
        grounds = new List<Transform>();
        for (int i = 0; i < MAXGroundCount; i++)
        {
            SpawnGround();
        }
    }
    void ControlGroundsCount()
    {
        if (grounds.Count > MAXGroundCount)
        {
            Destroy(grounds[0].gameObject);
            grounds.RemoveAt(0);
        }
    }
    public void ControlSpawnGround()
    {
        int groundsCountUnderPlayer = 0;
        foreach(Transform ground in grounds)
        {
            if (ground.position.y < player.transform.position.y)
            {
                groundsCountUnderPlayer++;
            }
        }
        if (groundsCountUnderPlayer < MINGroundCountUnderPlayer)
        {
            SpawnGround();
            ControlGroundsCount();
        }
    }
    float NewGroundPositionX()
    {
        if (grounds.Count == 0)
        {
            return 0;
        }
        return Random.Range(leftedge, rightedge);
    }

    float NewGroundPositionY()
    {
        if (grounds.Count == 0)
        {
            return initPositionY;
        }
        int lowerIndex = grounds.Count - 1;
        return grounds[lowerIndex].transform.position.y - spacingY;
    }

    void SpawnGround()
    {
        GameObject newGround = Instantiate(Resources.Load<GameObject>("floor"));
        //float newGroundY = initPositionY - (spacingY * i);
        newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        grounds.Add(newGround.transform);
    }
    float CountLowerGroundFloor()
    {
        float playerPositioY = player.transform.position.y;
        float deep = Mathf.Abs(initPositionY - playerPositioY);
        return (deep / singleFloorHeight)+1;
    }
    void DisplayCountFloor()
    {
        displayCountFloor.text = "level" + CountLowerGroundFloor().ToString("0000");
    }
    void Update()
    {
        ControlSpawnGround();
        DisplayCountFloor();
    }
}
