using UnityEngine;
using UnityEngine.InputSystem;

namespace Moonshine.Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private Transform cameraFollowObject;
        
        private float xRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            float mouseX = 0f;
            float mouseY = 0f;

            if (Mouse.current != null)
            {
                mouseX = Mouse.current.delta.ReadValue().x * sensitivity;
                mouseY = Mouse.current.delta.ReadValue().y * sensitivity;

                xRotation = Mathf.Clamp(xRotation + mouseY * Time.fixedDeltaTime, -60, 60);

                cameraFollowObject.localEulerAngles = new Vector3(-xRotation, cameraFollowObject.localEulerAngles.y, cameraFollowObject.localEulerAngles.z);

                transform.Rotate(Vector3.up * mouseX * Time.fixedDeltaTime);
            }
        }
    }
}
