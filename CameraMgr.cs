using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMgr : MonoBehaviour
{
    public Camera MainCamera;
    public Camera PicCam;
    public Camera SideCam;
    public Camera SplitUpperCam;
    public Camera SplitLowerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            Vector3 diff = Vector3.forward * Input.mouseScrollDelta.y;

            if (MainCamera.enabled) MainCamera.transform.Translate(diff);

            else if (SideCam.enabled) SideCam.transform.Translate(diff);

            else if (SplitLowerCam.enabled) SplitLowerCam.transform.Translate(diff);
        }
    }

    public void OnSliderValueChanged(float value)
    {
        Debug.LogFormat("Slider:{0}", value);
        // Code will go here
        if (MainCamera.enabled)
        {
            MainCamera.nearClipPlane = value;
        }
        else if (SideCam.enabled)
        {
            SideCam.nearClipPlane = value;
        }
        else if (SplitLowerCam.enabled)
        {
            SplitLowerCam.nearClipPlane = value;
        }
    }

    public void SwitchViews(Dropdown change)
    {
        Debug.LogFormat("{0}:{1}",change.itemText.text,
            change.value);
        switch (change.value)
        {
            //show Camera 1 view only
            case 0:
                MainCamera.enabled = true;
                PicCam.enabled = false;
                SideCam.enabled = false;
                SplitUpperCam.enabled = false;
                SplitLowerCam.enabled = false;

                break;
            //Show Camera 1 view only
            case 1:
                MainCamera.enabled = false;
                PicCam.enabled = false;
                SideCam.enabled = true;
                SplitUpperCam.enabled = false;
                SplitLowerCam.enabled = false;

                break;
            //Show Picture in Picture
            //With main camera enabled
            case 2:
                MainCamera.enabled = true;
                PicCam.enabled = true;
                SideCam.enabled = false;
                SplitUpperCam.enabled = false;
                SplitLowerCam.enabled = false;

                break;
                //Show Spilt Screen
            case 3:
                MainCamera.enabled = false;
                PicCam.enabled = false;
                SideCam.enabled = false;
                SplitUpperCam.enabled = true;
                SplitLowerCam.enabled = true;

        }
    }
}
