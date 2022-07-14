
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        FollowingPlayer();
    }



    private void FollowingPlayer()
    {
        
        // Move camera as  player moves;

        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }


    }
    
    
    
    
}
