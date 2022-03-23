using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : ITask
{
    protected List<ITask> childTasks = new List<ITask>();
    public abstract bool Execute();

}
