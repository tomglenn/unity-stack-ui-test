using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;

public class AnimatedScreen : MonoBehaviour, IScreen
{
    [SerializeField] private float animationTime = 0.5f;
    [SerializeField] private float offscreenXOffset = 1080;
    
    public Task Init(IDictionary<string, object> data = null)
    {
        GetComponent<RectTransform>().DOAnchorPosX(offscreenXOffset, 0);
        return Task.CompletedTask;
    }
    
    public async Task Enter()
    {
        GetComponent<RectTransform>().DOAnchorPosX(0, animationTime);
        await Task.Delay(TimeSpan.FromSeconds(animationTime));
    }

    public Task Suspend()
    {
        return Task.CompletedTask;
    }

    public Task Resume()
    {
        return Task.CompletedTask;
    }

    public async Task Exit()
    {
        GetComponent<RectTransform>().DOAnchorPosX(offscreenXOffset, animationTime);
        await Task.Delay(TimeSpan.FromSeconds(animationTime));
    }
}
