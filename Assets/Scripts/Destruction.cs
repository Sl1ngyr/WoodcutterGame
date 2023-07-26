using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
using Update = UnityEngine.PlayerLoop.Update;

public class Destruction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Scoring _scoringBranch;
    private IEnumerator _checkAnimationI;
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.TryGetComponent<DestroyTree>(out DestroyTree destroyTree) && coll.gameObject.tag.Equals("Tree"))
        {
            _checkAnimationI = PlayAnimAttack(1.05f, destroyTree);
            if (destroyTree.isActiveAndEnabled == true)
            {
                StartCoroutine(_checkAnimationI);
            }
            
        }
        
        if (coll.gameObject.tag.Equals("Branch"))
        {
            _scoringBranch.AddScore(1);
            Destroy(coll.gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (_checkAnimationI != null)
        {
            StopCoroutine(_checkAnimationI);
        }
    }
    
    private IEnumerator PlayAnimAttack(float time, DestroyTree destroyTree)
    {
        bool checkTree = true;
        while (checkTree)
        {
            animator.Play("Attack");
            yield return new WaitForSeconds(time);
            if (destroyTree.isActiveAndEnabled == true)
            {
                destroyTree.takeDamage();
            }
            else
            {
                checkTree = false;
            }
        }
    }
}



