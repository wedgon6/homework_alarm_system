using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameFinishTrigger : MonoBehaviour
{
    private EndGame[] _points;

    private void OnEnable()
    {
        //_points = GameObject.FindObjectsOfType<EndGame>();
        _points = gameObject.GetComponentsInChildren<EndGame>();

        foreach (var poit in _points)
        {
            poit.Reached += OnEndPointReached;
        }
    }

    private void OnDisable()
    {
        foreach (var poit in _points)
        {
            poit.Reached -= OnEndPointReached;
        }
    }

    private void OnEndPointReached()
    {
        foreach (var poit in _points)
            if (poit.IsReached == false) 
        return;

        Debug.Log("Level Finish");
    }
}
