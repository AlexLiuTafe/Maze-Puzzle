using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score = 1;
    
    public void Collect()
    {
        //Adding score to the manager
        Destroy(gameObject); // Remove item
    }
    

}
