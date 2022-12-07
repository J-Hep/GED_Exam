using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour, IPooled
{

    public void OnObjectSpawn()
    {
        Debug.Log("Release the ducks");
    }

}
