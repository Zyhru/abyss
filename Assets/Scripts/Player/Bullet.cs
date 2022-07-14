using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PlayerGun playerGun;
    [SerializeField] private int speed;


    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerGun = FindObjectOfType<PlayerGun>();
    }


    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemybase = collision.GetComponent<EnemyBase>();

        if (collision.gameObject.CompareTag("TileMap"))
        {
            Destroy(gameObject);
        }


        if (enemybase != null)
        {
            enemybase.TakeDamage(playerGun.GetWeapon().damage);

            Destroy(gameObject);
            
            

        }
    }
}