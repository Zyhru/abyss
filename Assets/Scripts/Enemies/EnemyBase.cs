using System.Collections;
using Camera;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public Enemy enemyStats;


    [SerializeField] protected int damage;
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;


    private ChaosMeter _chaosMeter;
    private CameraShake _cameraShake;
    private Animator anim;
    private SpriteRenderer sprite;


    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        _chaosMeter = FindObjectOfType<ChaosMeter>();
        _cameraShake = FindObjectOfType<CameraShake>();
        
        
        Init();
        
    }

    void Update()
    {
        Move();
        
        if (target != null)
        {
            sprite.flipX = (target.position.x > transform.position.x);
        }
    }

    protected virtual void Init()
    {
        damage = enemyStats.damage;
        health = enemyStats.health;
        speed = enemyStats.speed;
    }

    public virtual void TakeDamage(int damage)
    {
        if (anim != null)
        {
            anim.SetTrigger("Hurt");
        }

        health -= damage;
        AudioManager.instance.Play("EnemyHurt");

        if (health <= 0)
        {
            _chaosMeter.IncreaseChaosMeter(.5f);
            StartCoroutine(_cameraShake.Shake(.15f, .2f));
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        anim.SetTrigger("Death");
        WaveSpawner.instance.SpawnHearts(transform.position);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
        
        
    }

    public virtual void Attack(Collision2D other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack(other);
        }
    }


    public float Speed
    {
        get => speed;
        set => speed = value;
    }


    public int Health
    {
        get => health;
        set => health = value;
    }


    public int Damage
    {
        get => damage;
        set => damage = value;
    }
    
    protected abstract void Move();
    
    
}