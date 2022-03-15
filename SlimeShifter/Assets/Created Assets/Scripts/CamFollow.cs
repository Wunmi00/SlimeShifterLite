using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset;
    [Range(1,10)]
    public float smoothVal;

    private void LateUpdate()
    {
        followPlayer();
    }

    void followPlayer()
    {
        Vector3 targetPos = player.position + camOffset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothVal*Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}
