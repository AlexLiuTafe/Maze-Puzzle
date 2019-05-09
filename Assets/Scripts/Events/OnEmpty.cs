using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnEmpty : MonoBehaviour
{
    public UnityEvent onEmpty;
    
    void Update()
    {
        //Check if there are no more children left
        if(transform.childCount == 0)
        {
            //Run the subcribed events
            onEmpty.Invoke();
            //Disable the script
            enabled = false; //..So Update doesnt get called again
        }
    }
}
