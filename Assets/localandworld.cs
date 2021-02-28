using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localandworld : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        //Transform parent_transform = transform.parent;
        //Vector3 parent_position = parent_transform.position;

        //draw zoro transforms
        /*Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero, Vector3.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Vector3.zero, Vector3.up);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward);

        //draw parent transforms
        Gizmos.color = Color.red;
        Gizmos.DrawRay(parent_position, parent_transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(parent_position, parent_transform.up);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(parent_position, parent_transform.forward);*/

        //local to world
        
        /*Vector3 my_position = GetComponent<Transform>().localPosition;
        Vector3 local_to_world_pos= local_to_world(parent_transform, parent_position, my_position);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(local_to_world_pos, 0.1f);*/

        //world to local
        /*Vector3 local_my_pos = transform.position - parent_position;
        Vector3 local_my_pos_with_rotation = new Vector3(Vector3.Dot(local_my_pos, parent_transform.right),
                                           Vector3.Dot(local_my_pos, parent_transform.up),
                                           Vector3.Dot(local_my_pos, parent_transform.forward));
        //Vector3 local_my_pos_with_rotation = transform.parent.InverseTransformPoint(transform.position);
        Vector3 local_to_world_reference = local_to_world(parent_transform, parent_position, local_my_pos_with_rotation);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(local_to_world_reference, 0.05f);*/
    }

    /*private Vector3 local_to_world(Transform parent_transform, Vector3 parent_position, Vector3 my_position)
    {
        //return transform.TransformPoint(my_position);
        Vector3 local_and_rotation = (my_position.x * parent_transform.right +
                                    my_position.y * parent_transform.up +
                                    my_position.z * parent_transform.forward);
        Vector3 world_position = local_and_rotation + parent_position;
        return world_position;
    }*/
}
