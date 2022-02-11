using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform triggerInteractionObj;
    public Transform inSightObj;

    [Range(0f, 6f)]

    public float radius = 0;
    //value representing when an object looks at a trigger 
    //This threshold can be from 0 to 1 where 0 means you have to look at least perpendicular or closer and 1 means you have to be looking exactly at the trigger

    private void OnDrawGizmos()
    {
        Vector2 triggerPosition = triggerInteractionObj.position;
        Vector2 insights = inSightObj.position;
        Vector2 originPoint = transform.position;

        Vector3 facingTrigger = transform.TransformDirection(Vector3.forward);

        Vector3 placement = inSightObj.position - transform.position;

        float distance = Vector2.Distance(triggerPosition, originPoint);

        //if distance between objects is less then radiaus then boolean is true
        bool insideTrigger = distance < radius;

        if (insideTrigger)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawSphere(originPoint, radius);

        //determines whether the object is looking at the trigger
        //if less than 0 its not looking at the trigger
        if (Vector3.Dot(facingTrigger, placement) < 0)
        {

            //set color to red
            Gizmos.color = Color.red;


        }
        //else it is looking at the trigger
        else
        {
            //change color to green
            Gizmos.color = Color.green;

        }
        //Draw Gizmo Line
        Gizmos.DrawLine(originPoint, placement);





    }
}


//Dot Product A has to be normalized
//calculate dot (vector a and vector b =a.x times b.x + a.y times b.y
