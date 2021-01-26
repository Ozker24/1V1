using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Dependencies")]
    [HideInInspector] public TheLibrary library;
    CharacterController character;
    [Header("Movement Parameters")]
    Vector3 movementVector;
    public float speed;

    bool itsMoving => library.inputManager.movementVector.magnitude >= 0.1;
    #endregion

    #region Events
    public void Awake()
    {

    }
    public void Start()
    {
        character = GetComponent<CharacterController>();
    }

    public void Update()
    {
        GetAxis();
        Move();
        DrawDirection();
    }
    #endregion

    #region Methods
    void GetAxis()
    {

    }
    /// <summary>
    /// Moves the character.   	
    /// </summary>
    private void Move()
    {
        Vector3 localRotation = library.inputManager.movementVector.x * transform.right + library.inputManager.movementVector.y * transform.forward; //Multiplico los vectores de direccion  por los inputs para saber en que direccion se desplaza el jugador sobre los vectores de dirección. 
        movementVector = new Vector3(localRotation.x * speed, 0, localRotation.z * speed);

        movementVector.y = 0;
        Vector3 dir = library.thirdPersonCamera.camera.transform.TransformDirection(movementVector); //transforma "movementVect" a un vector correspondiente segun el transform de la camara
        dir.Set(dir.x, 0, dir.z);
        movementVector = dir.normalized * movementVector.magnitude;

        if (itsMoving) character.Move(movementVector * Time.deltaTime);
    }
    /// <summary>
    /// Draws the foward vector of the camera.   	
    /// </summary>
    void DrawDirection()
    {
        Vector3 camForward = Vector3.ProjectOnPlane(library.thirdPersonCamera.camera.transform.forward, Vector3.up);
        Debug.DrawRay(transform.root.position, camForward.normalized * 10, Color.red);
    }
    #endregion
}