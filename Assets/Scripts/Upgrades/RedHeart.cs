using UnityEngine;
using Upgrades;


public class RedHeart : AUpgrade
{
    [SerializeField] private PlayerHealth _playerHealth;

    protected override void Init()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public override void Upgrade()
    {
        if (_playerHealth != null)
        {
            _playerHealth.IncreaseHealth();
            Destroy(gameObject);
            
        }
    }
    
    

}