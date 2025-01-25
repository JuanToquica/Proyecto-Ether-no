using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouse : MonoBehaviour
{
        public bool isMouseLocked = true;

    void LockMice()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isMouseLocked = true;
        }

        void UnlockMice()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isMouseLocked = false;
        }

        void OnEnable()
        {
            UnlockMice();
        }

        void OnDisable()
        {
            LockMice();
        }
    }



