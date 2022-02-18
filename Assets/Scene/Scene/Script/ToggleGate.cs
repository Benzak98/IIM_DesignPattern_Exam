using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGate : MonoBehaviour
{
    int nbrToggle = 0;

    public void AddToggle()
    {
        nbrToggle++;
        if (nbrToggle >= 3)
            CheckToggle();
    }

    public void RemoveToggle()
    {
        nbrToggle--;
    }

    public void CheckToggle()
    {
        gameObject.SetActive(false);
    }
}
