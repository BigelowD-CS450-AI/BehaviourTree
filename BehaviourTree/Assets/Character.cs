using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Door door;
    //Character character = GameObject.FindObjectOfType<Character>();
    Vector3 distance;
    float distanceOffset = 1.0f;
    bool infrontOfDoor = false;
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
        distance = door.GetPosition() - transform.position;
        infrontOfDoor = false;
    }

    public void RunBehaviourTree()
    {
        //door.SetState();
        behaviourTree.Execute();
    }

    public IEnumerator MoveToDoor()
    {
        float duration = 10.0f;
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
        float duration = 10.0f;
        Vector3 origin = transform.position;
        Vector3 destination = door.GetPosition() + distance.normalized * distanceOffset * 2;
        destination.y = transform.position.y;
        for (float t = 0; t < duration; t += Time.fixedDeltaTime)
        {
            transform.position = Vector3.Lerp(origin, destination, t / duration);
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
}
