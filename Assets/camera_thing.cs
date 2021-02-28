using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_thing : MonoBehaviour
{
    public radius [] points;
    private void OnDrawGizmos()
    {
        /*Vector2 rel_distance = point.position - transform.position;
        float adjacent = rel_distance.x;
        float opposite = rel_distance.y;
        GetComponent<Camera>().fieldOfView = 2 * Mathf.Atan(opposite / adjacent) * Mathf.Rad2Deg;*/
        
        float angle_formed = float.MinValue;
        Vector2 side=Vector2.zero;
        foreach (radius point in points)
        {
            Gizmos.DrawWireSphere(point.transform.position, point.radii);
            Vector3 pt= transform.InverseTransformDirection(point.transform.position);
            Vector2 pt_flat = new Vector2(pt.x, pt.y);
            float angle = Mathf.Acos(Vector2.Dot(pt_flat.normalized, transform.right));
            float extra_angle = Mathf.Asin(point.radii / pt_flat.magnitude);
            angle += extra_angle;
            if (angle > angle_formed) 
            {
                side = point.transform.position;
                angle_formed = angle;
            }

        }
        Vector3 reel_distance = (Vector3)side - transform.position;
        reel_distance = reel_distance.normalized * reel_distance.magnitude * 2;
        Gizmos.DrawLine(transform.position, transform.position+reel_distance);
        GetComponent<Camera>().fieldOfView = 2 * angle_formed;
    }
}