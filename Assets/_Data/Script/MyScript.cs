using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        //this.TestOperator();
        //this.TestClass();
        //this.TestisDead();
    }

    void TestisDead()
    {
       
    }

    void TestClass()
    {
        Zombie zombie = new Zombie();
        Wolf wolf = new Wolf();

        zombie.Moving();
        wolf.Moving();
    }

    void TestOperator()
    {
        //int variable = 100 + 100;
        //Debug.Log("variable: " + variable);

        //int a = 2;
        //int b = 3;
        //bool c = 2 == 3;
        //Debug.Log("c: " + c);
    }
    
}
