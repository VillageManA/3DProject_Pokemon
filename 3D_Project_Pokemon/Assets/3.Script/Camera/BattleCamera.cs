using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BattleCamera : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    public int activeCameraIndex = 0;

    public void SwitchCamera(int newIndex)
    {
        if (newIndex < 0 || newIndex >= virtualCameras.Length)
            return;

        virtualCameras[activeCameraIndex].gameObject.SetActive(false);
        activeCameraIndex = newIndex;
        virtualCameras[activeCameraIndex].gameObject.SetActive(true);
    }
}
