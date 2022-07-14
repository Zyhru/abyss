
using UnityEngine;

public class MeleeEnemy : EnemyBase
{

    protected override void Move()
    {
        // Follow player and attack

        if (target != null)
        {
            distance = Vector2.Distance(transform.position, target.position);
            if (distance >= 0)
            {
                // Move towards player
                transform.position = Vector2.MoveTowards(transform.position, target.position,
                    speed * Time.deltaTime);
            }
        }
    }
}