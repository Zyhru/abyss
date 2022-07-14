
using UnityEngine;
using Random = UnityEngine.Random;

// TODO set a bulletSpread for each gun. Mainly for the shotgun
// TODO When player selects 1 then equip what ever is in 1. hotbar

/**
 * Rotate gun based on cursor position
 * 
 */
public class PlayerGun : MonoBehaviour
{
    public Weapon[] weapons;
    public Transform[] activeGuns;
    public Transform gun, firePoint;
    public Weapon currentWeapon;

    public UnityEngine.Camera cam;


    private SpriteRenderer sprite;
    private float angle;
    private float delay;
    private int damage;
    private int magSize;
    private int bulletsToShoot;
    private bool pickedUp;


    // Start is called before the first frame update
    void Start()
    {
        delay = currentWeapon.fireRate;
        magSize = currentWeapon.ammo;
        damage = currentWeapon.damage;
        bulletsToShoot = currentWeapon.bulletSpread;

        pickedUp = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();


        delay -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            // StartCoroutine(camera.Shake(duration, magnitude));

            if (delay <= 0)
            {
                Fire();
                delay = currentWeapon.fireRate;
            }
        }
    }


    public void SetGun(Weapon w)
    {
        currentWeapon = w;


        for (int i = 0; i < activeGuns.Length; i++)
        {
            if (i == w.id)
            {
                activeGuns[i].gameObject.SetActive(true);
            }
            else
            {
                activeGuns[i].gameObject.SetActive(false);
            }
        }
    }


    public void IncreaseMagSize(int amount)
    {
        magSize += amount;
    }

    public Weapon GetWeapon()
    {
        return currentWeapon;
    }

    private void RotateGun()
    {
        // NOTE (zai) We get the direction of where the gun should look at
        // NOTE (zai) Atan2 returns the angle of which the gun should look 
        // NOTE (zai) Finally, we rotate our gun based on our angle

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - gun.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        FlipGun();

        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


    private void FlipGun()
    {
        // Flip gun depending on gun is equipped.
        for (int i = 0; i < activeGuns.Length; i++)
        {
            if (angle > -89 && angle < 89)
            {
                activeGuns[i].GetComponent<SpriteRenderer>().flipY = false;
            }
            else
            {
                activeGuns[i].GetComponent<SpriteRenderer>().flipY = true;
            }


            if (pickedUp)
            {
                activeGuns[i].rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    private void Fire()
    {
        // Everytime player shoot decrease the magazine size by the bullet spread
        // Player can no longer gun if mag size is <= 0
        // Decrease ammo every time you shoot


        AudioManager.instance.Play("Shoot");
        for (int i = 0; i < currentWeapon.bulletSpread; i++)
        {
            float spread = Random.Range(-10, 10);
            Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angle + spread));
            Instantiate(currentWeapon.bullet, firePoint.position, bulletRotation);
        }
    }
}