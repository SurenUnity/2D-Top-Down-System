using System;
using UnityEngine;

namespace Controllers
{
    public class InputController : MonoControllers
    {
        public event Action<Vector3> mouseClickPosition;

        public override void Start()
        {

        }

        public override void Update(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;

                var convertedPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                mouseClickPosition?.Invoke(convertedPosition);
            }
        }
    }
}
