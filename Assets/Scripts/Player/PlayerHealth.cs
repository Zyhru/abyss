

using System.Collections;
using System.Collections.Generic;
using Camera;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public CameraShake _cameraShake;
    public ChaosMeter _chaosMeter;
    public ParticleSystem particle;
    public GameObject[] guns;
    public List<Image> hearts;

    
    private Animator _animator;
 



    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
        _animator = GetComponent<Animator>();

        if (_chaosMeter.ChaosMeterValue <= 0)
        {
            StartCoroutine(nameof(ChaosDeath));

        }
     
       
    }


    public int Health => health;


    public void TakeDamage(int damage)
    {
        
        health -= damage;

        AudioManager.instance.Play("Hit");

        _animator.SetTrigger("Hurt");

        if (health <= 0)
        {
           
        
            PlayerDeath();
          
        }
    }

    void PlayerDeath()
    {
        _animator.SetTrigger("Death");
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);   
        }

        // Play Death animation
        // Shake Camera at the duration of the Death Animation
        StartCoroutine(_cameraShake.Shake(_animator.GetCurrentAnimatorStateInfo(0).length + 1f, .4f));
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        GetComponent<PlayerMovement>().playerSpeed = 0;
        GetComponent<PlayerGun>().enabled = false;


    }

    IEnumerator ChaosDeath()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        GetComponent<PlayerGun>().enabled = false;
        yield return new WaitForSeconds(2f);
        DeathScreen();
    }

    void DeathScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void IncreaseHealth()
    {
        health += 1;

        if (health >= 4)
        {
            health = 4;
        }
    }

    // When player takes damage they lose a heart.

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.gameObject.GetComponent<EnemyBase>();
            TakeDamage(enemy.Damage);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Puddle"))
        {
            TakeDamage(1);
        }
        
        
    }


  
}