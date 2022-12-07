using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoOnPoolCall : MonoBehaviour, IPooled
{
    //Function to do thing with Pooled objects
    public void OnObjectSpawn()
    {
        Debug.Log("WOW");
    }

}
