using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform Enemy;
    Vector3 offset;
    public float transition = 0.0f;
    public float animationDuration = 2.0f;
    public Vector3 animationOffset = new Vector3(0, 5, 5);
    void Start()
    {
        offset = transform.position - player.position;
    }

   
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        Vector3 targetPos1 = Enemy.position + offset;
        targetPos.x = 0;
        if (transition > 1.0f)
        {
            transform.position = targetPos;
        }
        else
        {
            transform.position = Vector3.Lerp(targetPos + animationOffset, targetPos, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            //transform.LookAt(offset + Vector3.up);
        }
      
    }
}
