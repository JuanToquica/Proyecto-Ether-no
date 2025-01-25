using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouse : MonoBehaviour
{
        public bool isMouseLocked = true;

        public void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isMouseLocked = true;
        }

        public void UnlockM()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isMouseLocked = false;
        }

        public void OnEnable()
        {
            UnlockM();
        }

        public void OnDisable()
        {
            LockMouse();
        }
    }



