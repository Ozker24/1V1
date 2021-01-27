using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    #region Variables
    [Header("Dependencies")]
    [HideInInspector] public TheLibrary library;
    [Tooltip("Reference of the Cinemachine camera Follow")] public GameObject cameraFollow;
    [Tooltip("Reference of the camera is using cinemachine")] public GameObject playersCamera;
    [Header("Rotation")]
    [Tooltip("Speed of rotation in both Axes")] public Vector2 rotationPower;
    [Header("Options")]
    public bool invertX;
    public bool invertY;
    Quaternion nextRotation;
    #endregion

    #region Events
    private void Awake()
    {

    }

    public void Start()
    {
        playersCamera = GameObject.FindGameObjectWithTag("ThirdPersonCamera");
    }

    public void Update()
    {
        RotateFollow();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Rotates the follow game object of the Cinemachine.   	
    /// </summary>
    void RotateFollow()
    {
        nextRotation = Quaternion.Lerp(cameraFollow.transform.rotation, nextRotation, Time.deltaTime * 1);

        cameraFollow.transform.rotation *= Quaternion.AngleAxis(library.inputManager.rotationVector.x * rotationPower.x * InvertXAxis(), Vector3.up);
        cameraFollow.transform.rotation *= Quaternion.AngleAxis(library.inputManager.rotationVector.y * rotationPower.y * InvertYAxis(), Vector3.right);

        var angles = cameraFollow.transform.localEulerAngles;
        angles.z = 0;

        var angle = cameraFollow.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340) angles.x = 340;
        else if (angle < 180 && angle > 40) angles.x = 40;

        cameraFollow.transform.localEulerAngles = angles;

        nextRotation = Quaternion.Lerp(cameraFollow.transform.rotation, nextRotation, Time.deltaTime * 1);
    }
    /// <summary>
    /// Inverts X Axis.   	
    /// </summary>
    int InvertXAxis()
    {
        int invert;

        if (invertX) invert = 1;
        else invert = -1;

        return invert;
    }
    /// <summary>
    /// Inverts Y Axis.   	
    /// </summary>
    int InvertYAxis()
    {
        int invert;

        if (invertY) invert = -1;
        else invert = 1;

        return invert;
    }
    #endregion
}