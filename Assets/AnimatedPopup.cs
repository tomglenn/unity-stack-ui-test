using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UI.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedPopup : MonoBehaviour, IScreen
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Color fadeColor = new Color(0, 0, 0, 150);
    [SerializeField] private float fadeTime = 0.25f;
    [SerializeField] private float animationTime = 0.5f;
    
    public Task Init(IDictionary<string, object> data = null)
    {
        if (data != null && data.ContainsKey("AlertText"))
        {
            panel.GetComponentInChildren<TextMeshProUGUI>().text = (string) data["AlertText"];
        }
        
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        panel.GetComponent<RectTransform>().localScale = Vector3.zero;
        return Task.CompletedTask;
    }
    
    public async Task Enter()
    {
        // This screen has entered the stack for the first time
        GetComponent<Image>().DOColor(fadeColor, fadeTime);
        await Task.Delay(TimeSpan.FromSeconds(fadeTime));

        panel.GetComponent<RectTransform>().DOScale(Vector3.one, animationTime);
        await Task.Delay(TimeSpan.FromSeconds(animationTime));
    }

    public Task Suspend()
    {
        // This screen has lost focus due to a new screen on the stack
        // Pause animations, disable ui elements etc...
        return Task.CompletedTask;
    }

    public Task Resume()
    {
        // This screen is at the top of the stack again
        // Re-enable ui elements, or gameplay etc...
        return Task.CompletedTask;
    }

    public async Task Exit()
    {
        // This screen has been completely popped off the stack, so gracefully transition away
        panel.GetComponent<RectTransform>().DOScale(Vector3.zero, animationTime);
        await Task.Delay(TimeSpan.FromSeconds(animationTime));
        
        GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), fadeTime);
        await Task.Delay(TimeSpan.FromSeconds(fadeTime));
    }
}
