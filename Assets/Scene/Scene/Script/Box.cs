using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    public bool canDestroy = true;
    [SerializeField] GameObject popo;

    public void Touch(int power)
    {
        if (canDestroy)
        {
            Destroy(gameObject);

            int rand = Random.Range(0, 3);
            if(rand == 2)
            {
                Instantiate(popo, transform.position, Quaternion.identity);
            }
        }
    }
}
