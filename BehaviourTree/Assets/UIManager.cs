using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Toggle doorOpen;
    public Toggle doorLocked;
    public Toggle correctRoom;
    public Toggle goingToBed;
    public Door door;
    public Character character;
    public void Start()
    {
        ResetSimulation();
    }
    public void OnDoorOpenChanged()
    {
        if (doorOpen.isOn)
        {
            door.Open();
            door.Lock(false);
            doorLocked.isOn = false;
        }
        else
            door.Close();
    }
    public void OnDoorLockedChanged()
    {
        if (door.IsOpen())
        {
            Debug.Log("Can't lock an open door");
            doorLocked.isOn = false;
        }
        else
            door.Lock(doorLocked.isOn);
    }
    public void OnCorrectRoomChanged()
    {
        character.correctRoom = correctRoom.isOn;
    }
    public void OnGoingToBedChanged()
    {
        character.gointToBed = goingToBed.isOn;
    }
    public void RunBehaviourTree()
    {
        character.RunBehaviourTree();
    }
    public void ResetSimulation()
    {
        OnDoorOpenChanged();
        OnDoorLockedChanged();
        character.correctRoom = correctRoom.isOn;
        character.gointToBed = goingToBed.isOn;
        character.Reset();
    }
}
