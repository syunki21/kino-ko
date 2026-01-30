using UnityEngine;

public class BadMushroom : MonoBehaviour
{
    [Header("ˆÚ“®İ’è")]
    public float moveSpeed = 2f;

    Transform player;
    bool isActive = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isActive || player == null)
            return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    // “d’rØ‚ê‚ÅŒÄ‚Î‚ê‚é
    public void Activate()
    {
        isActive = true;
    }
}
