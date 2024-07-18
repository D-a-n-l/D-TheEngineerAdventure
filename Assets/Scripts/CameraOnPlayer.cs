using UnityEngine;
using System.Collections;
using System;

public class CameraOnPlayer : MonoBehaviour
{
    [SerializeField]
    public float Upp;
    [SerializeField]
    public float Down;
    [SerializeField]
    public float Right;
    [SerializeField]
    public float Left;

    public Transform target;
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 2, -5);
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, Left, Right),
            Mathf.Clamp(transform.position.y, Down, Upp),
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(Left, Upp), new Vector2(Right, Upp));
        Gizmos.DrawLine(new Vector2(Left, Down), new Vector2(Right, Down));
        Gizmos.DrawLine(new Vector2(Left, Upp), new Vector2(Left, Down));
        Gizmos.DrawLine(new Vector2(Right, Upp), new Vector2(Right, Down));
    }
}