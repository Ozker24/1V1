using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region variables
    [Header("Dependencies")]
    PlayerControls controls;
    [Header("Vectors")]
    public Vector2 movementVector;
    public Vector2 rotationVector;
    #endregion

    #region Events
    public void Awake()
    {
        SetInputs();
    }
    public void Start()
    {

    }

    public void Update()
    {

    }
    #endregion

    #region Methods
    /// <summary>
    /// Sets all the inputs.   	
    /// </summary>
    void SetInputs()
    {
        controls = new PlayerControls();

        controls.Enable();

        controls.Player.Movement.performed += ctx => GetMovementsDirection(ctx.ReadValue<Vector2>());
        controls.Player.Movement.canceled += ctx => movementVector = Vector2.zero;

        controls.Player.Rotation.performed += ctx => GetRotationDirection(ctx.ReadValue<Vector2>());
        controls.Player.Rotation.canceled += ctx => rotationVector = Vector2.zero;
    }
    /// <summary>
    /// Gets the vector of movement of the joysticks.   	
    /// </summary>
    void GetMovementsDirection(Vector2 Dir)
    {
        movementVector = Dir;
    }
    /// <summary>
    /// Gets the vector of rotation of the joysticks.   	
    /// </summary>
    void GetRotationDirection(Vector2 Dir)
    {
        rotationVector = Dir;
    }
    #endregion
}
