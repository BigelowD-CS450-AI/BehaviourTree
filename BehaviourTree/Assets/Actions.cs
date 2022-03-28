using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    static Character character = GameObject.FindObjectOfType<Character>();
    static Door door = GameObject.FindObjectOfType<Door>();

    public static bool MoveToDoor()
    {
        Debug.Log("Move to Door");
        character.StartCoroutine("MoveToDoor");
        return true;
    }
    public static bool MoveToRoom()
    {
        Debug.Log("Move to Room");
        character.StartCoroutine("MoveToRoom");
        return true;
    }
    public static bool BargeDoor()
    {
        Debug.Log("Barge Door");
        character.StartCoroutine("BargeDoor");
        //character.BargeDoor();
        return true;
    }
    public static bool OpenDoor()
    {
        Debug.Log("Open Door");
        character.StartCoroutine("OpenOnceAtDoor");
        return true;
    }
    public static bool CloseDoor()
    {
        Debug.Log("Close Door");
        character.StartCoroutine("CloseOnceInRoom");
        return true;
    }
    public static bool LockDoor()
    {
        Debug.Log("Lock Door");
        character.StartCoroutine("LockOnceInRoom");
        return true;
    }
    public static bool LeaveRoom()
    {
        Debug.Log("Leave Room");
        character.StartCoroutine("LeaveRoom");
        return true;
    }
    public static bool LieDown()
    {
        Debug.Log("Lie Down");
        character.StartCoroutine("LieDown");
        return true;
    }
    public static bool SitDown()
    {
        Debug.Log("Sit Down");
        character.StartCoroutine("SitDown");
        return true;
    }
}
