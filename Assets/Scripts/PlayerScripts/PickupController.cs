using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public void OnPickedUp()
    {
        GameManager.instance.OnPlayerPickUp(this);
    }
}
