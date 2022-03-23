using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : ITask
{
    private Func<bool> conditionStatement;
    public Condition(Func<bool> conditionStatement)
    {
        this.conditionStatement = conditionStatement;
    }
    public bool Execute()
    {
        return conditionStatement();
    }
}
