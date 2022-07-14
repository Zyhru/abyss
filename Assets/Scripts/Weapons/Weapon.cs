
using UnityEngine;



[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    public GameObject bullet;
    public GameObject weaponImage;

    public string weaponName;
    public int bulletSpread;
    public int damage;
    public int ammo;
    public int id;
    public float fireRate;



}
