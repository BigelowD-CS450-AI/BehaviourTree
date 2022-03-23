using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : ITask
{
    ITask rootTask;
    public BehaviorTree()
    {
        rootTask = new Selector( new List<ITask>
            {
                //door open move to room
                new Sequence(new List<ITask> {
                      new Condition(Conditions.DoorOpen) ,
                      new Action(Actions.MoveToRoom)
                }),
                new Sequence(new List<ITask> {
                      new Action(Actions.MoveToDoor),
                      new Selector(new List<ITask> {
                          new Sequence(new List<ITask> {
                              new Condition(Conditions.DoorUnlocked),
                              new Action(Actions.OpenDoor)
                          }),
                          new Sequence(new List<ITask> {
                              new Condition(Conditions.DoorClosed),
                              new Action(Actions.BargeDoor)
                          })
                      }) ,
                      new Action(Actions.MoveToRoom)
                })
            });
        //rootTask = new Action(Actions.MoveToDoor);
    }
    public bool Execute()
    {
        return rootTask.Execute();
    }
}
