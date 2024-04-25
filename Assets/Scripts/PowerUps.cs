using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    /*lo que se hizo fue crear un pequeño gestor para los power ups con el fin de que trabajar su logica
 fuese algo mas sencillo y entendible, se podria haber realizado en el game manager, pero dada la 
cantidad de informacion que se hallaba en el mismo, por practicidad se trabajo aqui*/
    public int countFlagP;
    public int countShieldP;
    public bool isFlagPEx = true;
    public bool isShieldPEx = true;
    public bool isFlagPAct = false;
    public bool isShieldPAct = false;
    
    /*se crearon unas variables para manejar la logica de los power ups, el si estan activados o no
     y si se podriann activar o no dado el numero de power ups disponibles en el "inventario"*/

    void Update()
    {
        //lineas encargadas de verificar si quedan power ups usables o no
        if (countFlagP <= 0)
        {
            isFlagPEx = false;
            isFlagPAct = false;
        }
        //en caso de no haber mas, simplemente los desactiva
        if (countShieldP <= 0)
        {
            isShieldPEx = false;
            isShieldPAct = false;
        }
    }

    //en caso de querer dar un efecto visual a los botones de los power ups, similar al de los tiles al hacer click
    //se debe insertar en las siguientes funciones

    //funcion encargada de activar y desactivar el power up de la bandera en funcion de 
    //si hay o no hay mas power ups
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

    //funcion encargada de activar y desactivar el power up del escudo en funcion de 
    //si hay o no hay mas power ups
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
