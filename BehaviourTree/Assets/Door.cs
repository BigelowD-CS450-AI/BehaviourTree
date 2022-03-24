using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool isLocked = true;
    private Vector3 doorPosition;
    //Vector3 doorPos;
    // Start is called before the first frame update
    void Start()
    {
        doorPosition = GameObject.FindGameObjectWithTag("Door").transform.position;
        if (isOpen)
            Open();
    }
    public void SetOpenState(bool openState)
    {
        isOpen = openState;
    }
    public Vector3 GetPosition()
    {
        return doorPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsOpen()
    {
        return isOpen;
    }
    public bool IsLocked()
    {
        return isLocked;
    }
    public void Open()
    {
        isOpen = true;
        Vector3 openOffset = new Vector3(0.0f, -90.0f, 0.0f);
        transform.rotation = Quaternion.Euler(openOffset);
    }
    public void Close()
    {
        isOpen = false;
        Vector3 openOffset = new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(openOffset);
    }
    public void Lock(bool locked)
    {
        isLocked = locked;
    }
}
