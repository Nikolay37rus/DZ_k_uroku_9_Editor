using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TreeBase : MonoBehaviour
{
#if UNITY_EDITOR
    [ContextMenu("Position tree")]
    public void PositionTree()
    {
        if (Physics.Raycast(transform.position + Vector3.up * 100, Vector3.down, out var hit, 200,
            LayerMask.GetMask("Ground")))
        {
            
            Undo.RecordObject(transform, "position tree");

            transform.position = hit.point - hit.normal * .1f;

            Vector3 normal = hit.normal;

            Vector3 fwd = Vector3.Cross(normal, Vector3.right).normalized;
            fwd = Quaternion.AngleAxis(Random.Range(0, 360), normal) * fwd;
            transform.rotation = Quaternion.LookRotation(fwd, normal);
        }
    }
#endif
}

