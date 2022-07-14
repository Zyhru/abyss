using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items;

    public void OpenChest()
    {
        // Play audio


        // Shake camera?


        // Instantiate random object from items when player opens chest
        Debug.Log("Opening chest.");
        Instantiate(RandomItem(), transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }


    GameObject RandomItem()
    {
        int randomItem = Random.Range(0, items.Length - 1);
        return items[randomItem];
    }
    
    
}