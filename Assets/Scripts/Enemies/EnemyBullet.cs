
using UnityEngine;


 // playerPos will be for robots
 // player.position will be for position
public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int bulletSpeed;
    [SerializeField] private int bulletDamage;

    private Vector2 playerPos;
    private Vector3 direction;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerPos = player.position;
        direction = player.position - transform.position;
        

    }

  
    
    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position, playerPos, bulletSpeed *
        //     Time.deltaTime);

        transform.position += direction * bulletSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(bulletDamage);  Destroy(gameObject);
            
        }

        if (other.gameObject.CompareTag("TileMap"))
        {
            Destroy(gameObject);
        }


        
      
        
    
        
    }
}
