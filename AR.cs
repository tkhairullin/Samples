using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class AR : MonoBehaviour
{
    public RawImage display;
	public RawImage displayReversed;
	private WebCamTexture mCamera;
	WebCamDevice[] devices;
	public ButtonsManager BM;
	public Quaternion baseRotation;

	void Start()
	{
		devices = WebCamTexture.devices;
		mCamera = new WebCamTexture();
		mCamera.deviceName = devices[0].name;

		display.texture = mCamera;
		baseRotation = display.transform.rotation;
		mCamera.Play();
	}

	void Update()
    {
		if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
		{
			display.transform.rotation = baseRotation * Quaternion.AngleAxis(mCamera.videoRotationAngle - 90, Vector3.back);
		}

		if (BM.flipper)
        {
			StartCoroutine(CamChange());
		}
	}

	IEnumerator CamChange()
    {
		if (devices.Length > 1)
		{
			mCamera.Stop();
			if (mCamera.deviceName == devices[0].name)
			{
				mCamera.deviceName = devices[1].name;
			}
			else
			{
				mCamera.deviceName = devices[0].name;
			}

			mCamera.Play();
		}
		BM.flipper = false;
		yield return null;
	}
}
