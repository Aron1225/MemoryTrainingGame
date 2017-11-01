using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TETCSharpClient;
using TETCSharpClient.Data;
using Assets.Scripts;
using System;

public class TETCamera : MonoBehaviour,IGazeListener {
    private Camera cam;

    private double eyesDistance;
    private double baseDist;
    private double depthMod;

    private Component gazeIndicator;

    private Collider currentHit;

    private GazeDataValidator gazeUtils;

    // Use this for initialization
    void Start () {
        Screen.autorotateToPortrait = false;

        cam = GetComponent<Camera>();
        baseDist = cam.transform.position.z;
        gazeIndicator = cam.transform.GetChild(0);

        gazeUtils = new GazeDataValidator(30);

        GazeManager.Instance.AddGazeListener(this);
	}
    void IGazeListener.OnGazeUpdate(GazeData gazeData)
    {
        gazeUtils.Update(gazeData);
        throw new NotImplementedException();
    }
    
	
	// Update is called once per frame
	void Update () {
        Point2D userPos = gazeUtils.GetLastValidUserPosition();

        if(userPos!=null)
        {
            //mapping cam panning to 3:2 aspect ratio
            double tx = (userPos.X * 5) - 2.5f;
            double ty = (userPos.Y * 3) - 1.5f;


            eyesDistance = gazeUtils.GetLastValidUserDistance();
            depthMod = 2 * eyesDistance;

            Vector3 newPos = new Vector3(
                (float)tx,
                (float)ty,
                (float)(baseDist + depthMod));
            cam.transform.position = newPos;

            cam.transform.LookAt(Vector3.zero);

            double angle = gazeUtils.GetLastValidEyesAngle();
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z + (float)angle);
        }

        Point2D gazeCoords = gazeUtils.GetLastValidSmoothedGazeCoordinates();

        if (gazeCoords!=null)
        {
            Point2D gp = UnityGazeUtils.getGazeCoordsToUnityWindowCoords(gazeCoords);

            Vector3 screenPoint = new Vector3((float)gp.X, (float)gp.Y, cam.nearClipPlane + .1f);

            Vector3 planeCoord = cam.ScreenToWorldPoint(screenPoint);

            gazeIndicator.transform.position = planeCoord;

            checkGazeCollision(screenPoint);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            Application.LoadLevel(0);
        }
    }

    private void checkGazeCollision(Vector3 screenPoint)
    {
        Ray collisionRay = cam.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if(Physics.Raycast(collisionRay,out hit))
        {
            if (null != hit.collider && currentHit!=hit.collider)
            {
                if (null != currentHit)
                    currentHit.GetComponent<Renderer>().material.color = Color.white;
                currentHit = hit.collider;
                currentHit.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    void OnApplicationQuit()
    {
        GazeManager.Instance.RemoveGazeListener(this);
    }
}
