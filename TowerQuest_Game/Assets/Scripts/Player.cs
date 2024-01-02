using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

}

public interface IEntity
{ 
    int Health { get; set; }

   

    public void EnableInteraction();

    public void DisableInteraction();
}

public interface IPlayer : IEntity
{
    public void Attack();

    public void Risk();

    public void Support();
}


