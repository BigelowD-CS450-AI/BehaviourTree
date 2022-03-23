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

}
