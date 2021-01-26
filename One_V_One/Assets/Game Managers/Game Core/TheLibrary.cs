using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLibrary : MonoBehaviour
{
    #region Variables
    public InputManager inputManager;
    public ThirdPersonCamera thirdPersonCamera;
    public PlayerMovement character;
    #endregion

    #region Events
    private void Awake()
    {
        FindGameObjects();
        SetLibrary();
    }

    #endregion

    #region Methods
    /// <summary>
    /// Finds all the game objects which needs the library as reference.   	
    /// </summary>
    void FindGameObjects()
    {
        inputManager = GameObject.FindGameObjectWithTag("Managers").GetComponentInChildren<InputManager>();
        thirdPersonCamera = GameObject.FindGameObjectWithTag("ThirdPersonCamera").GetComponent<ThirdPersonCamera>();
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    /// <summary>
    /// Sets the library references for all the Game Objects they need it.   	
    /// </summary>
    void SetLibrary()
    {
        thirdPersonCamera.library = this;
        character.library = this;
    }
    #endregion

    #region Corrutines

    #endregion
}