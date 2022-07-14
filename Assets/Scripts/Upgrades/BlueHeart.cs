using UnityEngine;
using Upgrades;

public class BlueHeart : AUpgrade
{
    [SerializeField] private ChaosMeter _chaosMeter;
    private float amount;

    protected override void Init()
    {
         amount = 1;
        _chaosMeter = FindObjectOfType<ChaosMeter>();
    }

    public override void Upgrade()
    {
        if (_chaosMeter != null)
        {
            _chaosMeter.IncreaseChaosMeter(amount);
            Destroy(gameObject);
        }
    }
}