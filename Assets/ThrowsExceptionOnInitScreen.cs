using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;

public class ThrowsExceptionOnInitScreen : MonoBehaviour, IScreen
{
    public Task Init(IDictionary<string, object> data = null)
    {
        throw new Exception("Not all those who wander are lost.");
    }
    
    public Task Enter()
    {
        return Task.CompletedTask;
    }

    public Task Suspend()
    {
        return Task.CompletedTask;
    }

    public Task Resume()
    {
        return Task.CompletedTask;
    }

    public Task Exit()
    {
        return Task.CompletedTask;
    }
}
