using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //base class might not need

}

public interface IPlayer
{ 
    int Health { get; set; }

    public  void Attack()
    {

    }

    public  void Risk()
    {

    }

    public  void Support()
    {

    }

    
}

