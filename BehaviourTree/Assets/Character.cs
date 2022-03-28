using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Door door;
    //Character character = GameObject.FindObjectOfType<Character>();
    Vector3 distance;
    float distanceOffset = 2.0f;
    public bool infrontOfDoor = false;
    public bool inRoom = false;
    public bool correctRoom;
    public bool gointToBed;
    Vector3 startPos;

    // BehaviorTree bt = new BehaviorTree();
    ITask behaviourTree = new BehaviorTree();

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        door = GameObject.FindObjectOfType<Door>();
        distance = door.GetPosition() - transform.position;
    }

    public void Reset()
    {
        StopAllCoroutines();
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        distance = door.GetPosition() - transform.position;
        infrontOfDoor = false;
        inRoom = false;
}

    public void RunBehaviourTree()
    {
        //door.SetState();
        behaviourTree.Execute();
    }

    public IEnumerator MoveToDoor()
    {
        float duration = 5.0f;
        Vector3 origin = transform.position;
        Vector3 destination = door.GetPosition() - distance.normalized * distanceOffset;
        destination.y = transform.position.y;
        for (float t = 0; t < duration; t += Time.fixedDeltaTime)
        {
            transform.position = Vector3.Lerp(origin, destination, t / duration);
            yield return null;
        }
        infrontOfDoor = true;
    }

    public IEnumerator MoveToRoom()
    {
        while (!door.IsOpen())
            yield return null;
        float duration = 5.0f;
        Vector3 origin = transform.position;
        Vector3 destination = door.GetPosition() + distance.normalized * distanceOffset * 2;
        destination.y = transform.position.y;
        for (float t = 0; t < duration; t += Time.fixedDeltaTime)
        {
            transform.position = Vector3.Lerp(origin, destination, t / duration);
            yield return null;
        }
        inRoom = true;
    }

    public IEnumerator LeaveRoom()
    {
        while (!inRoom)
            yield return null;
        float duration = 5.0f;
        Vector3 origin = transform.position;
        Vector3 destination = door.GetPosition() + distance.normalized * distanceOffset * 2;
        destination.y = transform.position.y;
        for (float t = 0; t < duration; t += Time.fixedDeltaTime)
        {
            transform.position = Vector3.Lerp(origin, startPos, t / duration);
            yield return null;
        }
    }

    private IEnumerator BargeDoor()
    {
        while (!infrontOfDoor)
            yield return null;
        Vector3 destination = door.GetPosition();
        destination.y = transform.position.y;
        transform.position = destination;
        door.Open();
    }

    public IEnumerator OpenOnceAtDoor()
    {
        while (!infrontOfDoor)
            yield return null;
        door.Open();
    }
    public IEnumerator CloseOnceInRoom()
    {
        while (!inRoom)
            yield return null;
        door.Close();
    }
    public IEnumerator LockOnceInRoom()
    {
        while (!inRoom)
            yield return null;
        door.Lock(true);
    }
    public IEnumerator LieDown()
    {
        while (!inRoom)
            yield return null;
        transform.position += new Vector3(0.0f, -0.5f, 0.0f);
        transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
    }
    public IEnumerator SitDown()
    {
        while (!inRoom)
            yield return null;
        transform.position += new Vector3(0.0f, -1.0f, 0.0f);
    }
}
