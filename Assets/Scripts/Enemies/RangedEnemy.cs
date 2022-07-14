using UnityEngine;

public class RangedEnemy : EnemyBase
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] firepoint;
    [SerializeField] private float shootTime;
    private float timer;


    protected override void Init()
    {
        base.Init();
        
        timer = shootTime;
        
    }

    protected override void Move()
    {
        if (target != null)
        {
            
            distance = Vector2.Distance(transform.position, target.position);
            if (distance < 10)
            {
                // Move towards player
                transform.position = Vector2.MoveTowards(transform.position, target.position,
                    speed * Time.deltaTime);
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (timer <= 0)
        {
            for (int i = 0; i < firepoint.Length; i++)
            {
                Instantiate(bullet, firepoint[i].position, firepoint[i].rotation);
            }

            timer = shootTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}