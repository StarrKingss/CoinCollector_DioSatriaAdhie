using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PemancarEvent : MonoBehaviour
{

    public static event Action SaatTombolDitekan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SaatTombolDitekan?.Invoke();
            Debug.Log("Tombol ditekan");
        }
    }
}
