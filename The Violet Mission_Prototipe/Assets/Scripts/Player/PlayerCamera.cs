#region Namespaces/Directives

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#endregion

public class PlayerCamera : MonoBehaviour
{
    #region Declarations

    [Header("Camera Movement Settings")]
    [SerializeField] float _mouseSensitivity;
    [SerializeField] float _cameraCurrentX = 0;
    Vector2 mouseDelta;

    [SerializeField] Camera _camera;

   // private GameManager _gm;

    private GameObject _player;

    #endregion

    #region Start and Update

    private void Start()
    {
      

        _player = GameObject.Find("Player");

    }
    private void LateUpdate()
    {

        UpdateMouseLook();
       
        
    }

    #endregion

    void UpdateMouseLook()
    {
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * _mouseSensitivity;

        _cameraCurrentX -= mouseDelta.y;

        _cameraCurrentX = Mathf.Clamp(_cameraCurrentX, -90, 90);

       _camera.transform.localEulerAngles = Vector3.right * _cameraCurrentX;
        transform.Rotate(Vector3.up * mouseDelta.x);
    }
}

