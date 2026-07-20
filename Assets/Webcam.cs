using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.RawImage _rawImageLeft;

    [SerializeField]
    private UnityEngine.UI.RawImage _rawImageRight;

    [SerializeField]
    private int leftCameraIdx;

    [SerializeField]
    private int rightCameraIdx;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log($"Webcam available [{i}]: {devices[i].name}");
        }

        if (leftCameraIdx >= devices.Length || rightCameraIdx >= devices.Length)
        {
            Debug.LogError("Camera index out of range!");
        }
        else
        {
            var left = new WebCamTexture(devices[leftCameraIdx].name);
            _rawImageLeft.texture = left;

            var right = new WebCamTexture(devices[rightCameraIdx].name);
            _rawImageRight.texture = right;

            left.Play();
            right.Play();
        }
    }
}
