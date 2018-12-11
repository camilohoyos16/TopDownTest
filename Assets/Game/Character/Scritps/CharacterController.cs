using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField] private float health;
    private int keysAmount;

    private bool canBeAttacked;
    private bool CanBeAttacked
    {
        get
        {
            return canBeAttacked;
        }
    }

    public void LoseHealth(float amountOfDamage)
    {

    }
    
}
