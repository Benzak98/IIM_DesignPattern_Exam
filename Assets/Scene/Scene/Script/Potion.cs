using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IObject
{
    [SerializeField] PlayerEntity player;
    [SerializeField] int amount;

    private void Awake()
    {
        player = FindObjectOfType<PlayerEntity>();
    }

    public void DetectPlayer()
    {
        Debug.Log("takepopo");
        player.Health.TakePopo(amount);
        Destroy(this.gameObject);
    }
}
