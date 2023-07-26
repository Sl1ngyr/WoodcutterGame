using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DestroyTree : MonoBehaviour
{
    private int _healthTree = 3;
    public GameObject branch;

    public void takeDamage()
    {
        --_healthTree;
        if (_healthTree <= 0)
        {
            Invoke(nameof(destroyTree), 0.5f);
            Instantiate(branch, new Vector3(transform.position.x, 2f, transform.position.z), Quaternion.identity);
            Invoke(nameof(RespawnTree), 15.0f);
        }
    }

    private void destroyTree()
    {
        gameObject.SetActive(false);
    }
    
    private void RespawnTree()
    {
        _healthTree = 3;
        gameObject.SetActive(true);
    }

}
