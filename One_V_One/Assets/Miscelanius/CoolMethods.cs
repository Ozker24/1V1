using UnityEngine;

public class CoolMethods
{
    #region Variables

    #endregion

    #region Events

    void Initialize()
    {

    }


    void MyUpdate()
    {

    }
    #endregion

    #region Methods
    public static TheLibrary GetLibrary()
    {
        TheLibrary library = GameObject.FindGameObjectWithTag("Managers").GetComponentInChildren<TheLibrary>();
        return library;
    }
    #endregion

    #region Corrutines

    #endregion
}
