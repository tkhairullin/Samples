using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonsManager : MonoBehaviour
{
    public Button Reset;
    public Button FlipCam;
    public Button Exit;

    public Transform Model;

    public bool flipper=false;

    public void ResetModel()
    {
        StartCoroutine(LerpAngle(1));
    }

    IEnumerator LerpAngle(float duration)
    {
        Model.DORotate(new Vector3(10, -160, 5), duration);
        yield return 0;
    }

    public void FlipCamera()
    {
        flipper = true;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
