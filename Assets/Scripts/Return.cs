using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System.Collections.Generic;

public class HoldButtonToReturn : MonoBehaviour
{
// public string mainMenuSceneName = "MenuScene";
    public float holdDuration = 2f;

    private float holdTimer = 0f;

    void Update()
    {
        bool buttonPressed = false;

        var devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        foreach (var device in devices)
        {
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed) && pressed)
            {
                buttonPressed = true;
                break;
            }
        }

        if (Input.GetKey(KeyCode.Escape)) // Optional fallback for desktop
        {
            buttonPressed = true;
        }

        if (buttonPressed)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= holdDuration)
            {
                // SceneManager.LoadScene(mainMenuSceneName);
                SceneManager.LoadScene("MenuScene");
            }
        }
        else
        {
            holdTimer = 0f;
        }
    }
}
