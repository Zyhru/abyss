using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;

    private GameObject _gameObject;
    private Inventory inventory;
    private PlayerGun _playerGun;

    private KeyCode alpha1 = KeyCode.Alpha1;
    private KeyCode alpha2 = KeyCode.Alpha2;
    private KeyCode alpha3 = KeyCode.Alpha3;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        _playerGun = GameObject.FindWithTag("Player").GetComponent<PlayerGun>();
    }


    private void Update()
    {
        if (inventory.list.Count > 0)
        {
            if (Input.GetKeyDown(alpha1))
            {
                _playerGun.SetGun(weapon);
            }


            if (Input.GetKeyDown(alpha2))
            {
                _playerGun.SetGun(inventory.list[0]);
            }

            if (Input.GetKeyDown(alpha3))
            {
                _playerGun.SetGun(inventory.list[1]);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if slot is full
        if (other.gameObject.CompareTag("Player"))
        {
            
            for (int i = 0; i < inventory.full.Length; i++)
            {
                // if inventory slot is not full
                if (!inventory.full[i])
                {
                    // Set the image 
                    Instantiate(weapon.weaponImage, inventory.hotbar[i].transform, false);
                    AudioManager.instance.Play("Pickup");
                    _playerGun.SetGun(weapon);


                    // Adding weapons to a list for reference to swap between weapons based on input
                    // E.G if user presses 1 , select pistol
                    inventory.list.Add(weapon);


                    // NOW SLOT IS NOW FULL 
                    inventory.full[i] = true;
                    

                    break;
                }

                Destroy(gameObject);
            }
        }
    }
}