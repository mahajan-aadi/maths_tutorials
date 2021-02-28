using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class maths : MonoBehaviour
{
    //spring
    const int points_per_turn= 64;
    public int turns=4;
    public float radius = 2;
    public float height=4;
    public float minor_radius = 0.2f;
    //other
    [Range(0,1)] public float T;
    [Range(3, 20)] [SerializeField] int sides = 3;
    [Range(1, 19)] [SerializeField] int density = 1;
    const float TAU = 6.2831853f;
    public Mesh mesh;
    public float area;
    [SerializeField] [Range(0, 90)] float lookness;
    [SerializeField] Transform point;
    public Transform point_a;
    public Transform point_b;
    [Range(0,4f)]public float sphere_drawn;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        //point
        Vector3 point = transform.position;

        //normalized point
        point = point.normalized;

        //distace
        /*Vector3 a = point_a.position;
        Vector3 b = point_b.position;
        float distance=  Vector3.Distance(a, b);
        float diatance = (a - b).magnitude;*/
        //Gizmos.DrawLine(Vector2.zero, point);

        //direction from one to another
        /* Vector3 pt_a = point_a.position;
         Vector3 pt_b = point_b.position;
         Vector3 pt_a_to_b = pt_b - pt_a;
         Vector3 distance = Vector3.Normalize(pt_a_to_b);
         Gizmos.DrawLine(pt_a,pt_a+distance);*/

        //point moving
        /*Vector3 center_point = distance * sphere_drawn;
        Gizmos.DrawSphere(pt_a+center_point, 0.1f);*/

        //radial trigger
        /*
        float distance = Vector3.SqrMagnitude(transform.position- point_a.position);
        bool condition = distance > sphere_drawn*sphere_drawn;
        Gizmos.color = condition ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, sphere_drawn);*/

        //look-at-trigger
        /*float lookness_rad = lookness * Mathf.Deg2Rad;
        Vector3 distance = Vector3.Normalize(point_b.position - point_a.position);
        Gizmos.DrawLine(point_a.position, point_a.position + distance);
        float dot_product = Vector3.Dot(distance, point_a.right);
        dot_product = Mathf.Clamp(dot_product, -1, 1);
        float angle = Mathf.Acos(dot_product);
        bool checking_equation = angle > lookness_rad;
        Gizmos.color = checking_equation ? Color.green : Color.red;
        Gizmos.DrawLine(point_a.position, point_a.position + point_a.right);*/

        //cross-product

        /*void draw_point(Vector3 main_pos, Vector3 extended_pos) => Gizmos.DrawLine(main_pos, main_pos + extended_pos); 
        Vector3 my_pos = transform.position;
        Vector3 forward_pos = transform.forward;
        if (Physics.Raycast(my_pos,forward_pos,out RaycastHit hit))
        {
            Vector3 hit_pos = hit.point;
            Vector3 hit_normal = hit.normal;
            Vector3 right = -Vector3.Cross(forward_pos, hit_normal).normalized;
            Vector3 forward = Vector3.Cross(right, hit_normal).normalized;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(my_pos, hit_pos);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(hit_pos, hit_normal);
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(hit_pos, right);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(hit_pos,forward);
            spheres(hit_pos, forward, right);
        }
        else
        {
            Gizmos.color = Color.red;
            draw_point(my_pos, forward_pos);
        }*/

        //regular polygon
        /*
        Vector2 func(float angle) => new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2[] verts = new Vector2[sides];
        for (int i = 0; i < sides; i++)
        {
            verts[i] = func(TAU / sides * i);
        }
        for (int i = 0; i < sides; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(verts[i], 0.1f);
        }
        for (int i = 0; i < sides; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(verts[i], verts[(i + density) % sides]);
        }*/

        //lerp
        /*
        Vector3 pos = Vector3.Lerp(point_a.position, point_b.position, T);
        Color col = Color.Lerp(Color.blue, Color.yellow, T);
        Gizmos.color = col;
        Gizmos.DrawSphere(pos, 0.1f);
        Gizmos.DrawLine(point_a.position, point_b.position);*/

        //inverse lerp
        /*
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Vector3.zero, 10f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, 5f);
        float number= Mathf.InverseLerp(10f, 5f, transform.position.magnitude);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Vector3.zero, number);
        */

        //spring
        /*float point_count = points_per_turn * turns;
        Vector3[] points = new Vector3[points_per_turn * turns]; 
        for(int i = 0; i < point_count; i++)
        {
            float angle = (i / (point_count-1)) * turns*TAU;
            float x_coor = radius * Mathf.Cos(angle);
            float z_coor = radius * Mathf.Sin(angle);
            float height_done = (i / (point_count-1)) * height;
            points[i] = new Vector3(x_coor, height_done, z_coor);
        }
        Handles.DrawAAPolyLine(points);*/

        //torus
        /*
        float point_count = points_per_turn * turns;
        Vector3[] points = new Vector3[points_per_turn * turns];
        Vector3[] main_side = new Vector3[points_per_turn * turns];
        for (int i = 0; i < point_count; i++)
        {
            float main_angle = (i / (point_count - 1)) * TAU;
            float x_coor = radius * Mathf.Cos(main_angle);
            float z_coor = radius * Mathf.Sin(main_angle);
            main_side[i] = new Vector3(x_coor, 0, z_coor);

            float minor_angle = (i / (point_count - 1)) * turns * TAU;
            float x_coor_min = minor_radius * Mathf.Cos(minor_angle);
            float y_coor_min = minor_radius * Mathf.Sin(minor_angle);
            points[i] = new Vector3(x_coor+x_coor_min,y_coor_min,z_coor);
            points[i]= main_side[i]+x_coor_min*main_side[i].normalized+y_coor_min*Vector3.up;
        }
        Handles.DrawAAPolyLine(main_side);
        Handles.DrawAAPolyLine(points);
        */


    }
    void spheres(Vector3 hit_pos,Vector3 forward,Vector3 right)
    {
            //matrix
            /*Quaternion rot = Quaternion.LookRotation(forward, right);
            Matrix4x4 matrix = Matrix4x4.TRS(hit_pos,rot,Vector3.one);
            Vector3[] points = {new Vector3(1,2,1), new Vector3(-1, 2, 1) , new Vector3(1, 2, -1) , new Vector3(-1, 2, -1),
                                new Vector3(1,0,1), new Vector3(-1, 0, 1) , new Vector3(1, 0, -1) , new Vector3(-1, 0, -1)};
            for(int i=0;i<points.Length; i++)
            {
                Vector3 point = matrix.MultiplyPoint3x4(points[i]);
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(point, 0.2f);
            }*/
    
    }

    void OnValidate()
    {
        //mesh
        /*area = 0;
        Vector3[] points=mesh.vertices;
        int[] tris = mesh.triangles;
        for(int i = 1; i <= tris.Length; i += 3)
        {
            Vector3 a = points[tris[i]];
            Vector3 b = points[tris[i+1]];
            Vector3 c = points[tris[i+2]];
            area += Vector3.Cross(a - b, a - c).magnitude;
        }
        area /= 2;*/

        }
    private void Start()
    {/*
        //realtive
        Quaternion rot_to_add = Quaternion.AngleAxis(45f, Vector3.up);
        //absolute
        Quaternion rot = Quaternion.LookRotation(transform.forward, transform.up);
        //add
        Quaternion add = rot*rot_to_add;        
        //subtract
        Quaternion sub = rot *Quaternion.Inverse(rot_to_add);
        transform.rotation = add;
        */
    }
}

