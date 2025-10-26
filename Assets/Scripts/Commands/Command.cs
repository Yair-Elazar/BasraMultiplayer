using UnityEngine;
using System.Collections.Generic;
public abstract class Command : MonoBehaviour
{
    private static Queue<Command> queue = new();
    private static bool isCommandPlaying = false;

    public void Enqueue()
    {
        queue.Enqueue(this);
        if (!isCommandPlaying)
        {
            ExecuteFirstCommand();
        }
    }

    private void ExecuteFirstCommand()
    {
        var cmd = queue.Dequeue();
        isCommandPlaying =  true;
        cmd.Execute();
    }

    public abstract void Execute();

    public void ExecuteComplete()
    {
        if (queue.Count > 0)
        {
            ExecuteFirstCommand();
        }
        else
        {
            isCommandPlaying = false;
        }
    }
}
