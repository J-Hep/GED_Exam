using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Interfaced function inherited by scripts wanting to use pooling
public interface IPooled
{

    void OnObjectSpawn();

}
