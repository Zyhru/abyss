


using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] full;
    public GameObject[] hotbar;
    public List<Weapon> list;

    void Start()
    {
        list = new List<Weapon>();
    }
    


}
