using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Conditions
{
    static Door door = GameObject.FindObjectOfType<Door>();
    static Character character = GameObject.FindObjectOfType<Character>();

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
    public static bool CorrectRoom()
    {
        Debug.Log("Checking Correct Room");
        return character.correctRoom;
    }
    public static bool GoingToBed()
    {
        Debug.Log("Checking Going to Bed");
        return character.gointToBed;
    }
}
