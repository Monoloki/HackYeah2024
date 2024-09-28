using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CutSceneManager : Singleton<CutSceneManager>
{
    public CinemachineVirtualCamera playerCamera;

    private CinemachineVirtualCamera lastUsedCamera;

    public void SwitchToCamera(CinemachineVirtualCamera targetCamera) {
        lastUsedCamera = targetCamera;
        lastUsedCamera.Priority = 99;
    }

    public void ResetCamera() {
        lastUsedCamera.Priority = 5;
    }
}
