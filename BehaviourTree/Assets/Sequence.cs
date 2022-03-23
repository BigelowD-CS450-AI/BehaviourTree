using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    public Sequence(List<ITask> childTasks)
    {
        this.childTasks = childTasks;
    }
    public override bool Execute()
    {
        foreach (ITask task in childTasks)
        {
            //execute all tasks
            if (!task.Execute())
                return false;
        }
        return true;
    }
}
