using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rBody = hit.collider.attachedRigidbody;

        if(rBody != null)
        {
            var forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            
        }
    }
}
