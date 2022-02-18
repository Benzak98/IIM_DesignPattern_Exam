using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IObject
{
    [SerializeField] GameObject key;
    [SerializeField] GameObject gate;

    public void DetectPlayer()
    {
        gate.SetActive(false);
        Destroy(key);
    }
}
