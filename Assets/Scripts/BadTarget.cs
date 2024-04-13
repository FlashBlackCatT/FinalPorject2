using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//INHERITANCE
public class BadTarget : Target
{



    //POLYMORPHISM
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        Debug.Log("BOOM");
    }
}
