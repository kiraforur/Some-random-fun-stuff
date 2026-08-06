using UnityEngine;

public class PlayerViewPoint : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private int playerId;

    public int PlayerId => playerId;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        
        Gizmos.DrawWireSphere(transform.position, 0.3f);

        
        Gizmos.DrawRay(
            transform.position,
            transform.forward * 2f);
    }
}
