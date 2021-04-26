using System;
using Controllers;
using UnityEngine;

public class CorApplication : MonoBehaviour
{
    [SerializeField] private Canvas _canvas = default;

    private SystemController _systemController;

    private void Awake()
    {
        _systemController = new SystemController(_canvas);
    }

    private void Update()
    {
        _systemController.Update(Time.deltaTime);
    }
}
