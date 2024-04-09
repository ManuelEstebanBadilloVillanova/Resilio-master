using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private int countFlagP;
    [SerializeField] private int countShieldP;
    public bool isFlagPEx = true;
    public bool isShieldPEx = true;
    public bool isFlagPAct = false;
    public bool isShieldPAct = false;

    void Update()
    {
        if (countFlagP <= 0)
        {
            isFlagPEx = false;
        }
        if (countShieldP <= 0)
        {
            isShieldPEx = false;
        }
    }

    public void ActivePowerFlag()
    {
        if (isFlagPEx == true & isShieldPAct == false)
        {
            if (isFlagPAct == false)
            {
                isFlagPAct = true;
            }
            else if (isFlagPAct == true)
            {
                isFlagPAct = false;
            }
        }
    }

    public void ActivePowerShield()
    {
        if (isShieldPEx == true & isFlagPAct == false)
        {
            if (isShieldPAct == false)
            {
                isShieldPAct = true;
            }
            else if (isShieldPAct == true)
            {
                isShieldPAct = false;
            }
        }
    }
}
