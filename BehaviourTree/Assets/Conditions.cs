using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Conditions
{
    static Door door = GameObject.FindObjectOfType<Door>();

    public static bool DoorOpen()
    {
        Debug.Log("Checking Door Open");
        return door.IsOpen();
    }
    public static bool DoorClosed()
    {
        Debug.Log("Checking Door Closed");
        return !door.IsOpen();
    }
    public static bool DoorUnlocked()
    {
        Debug.Log("Checking Door Locked");
        return !door.IsLocked();
    }
}
