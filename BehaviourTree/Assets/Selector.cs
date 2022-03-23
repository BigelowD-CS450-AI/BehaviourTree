using System;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public Selector(List<ITask> childTasks)
    {
        this.childTasks = childTasks;
    }
    public override bool Execute()
    {
        foreach (ITask task in childTasks)
        {
            //if one task returns true don't process others
            if (task.Execute())
                return true;
        }
        return false;
    }

}
