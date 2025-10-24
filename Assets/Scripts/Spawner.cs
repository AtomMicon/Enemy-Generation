using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.forward;

    public Vector3 SpawnPosition => transform.position;
    public Vector3 MoveDirection => transform.TransformDirection(moveDirection.normalized);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.3f);
        Gizmos.DrawRay(transform.position, moveDirection.normalized * 2f);
    }
}
