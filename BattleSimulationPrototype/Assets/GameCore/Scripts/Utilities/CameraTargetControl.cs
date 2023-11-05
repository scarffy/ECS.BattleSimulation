using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetControl : MonoBehaviour
{
    public float BoundingBoxLength=10;
    public float movespeeed = 4;

    private GameInput _inputActions;

    private Vector2 _moveVector;

    private bool _validMove;

    private void OnEnable()
    {
        _inputActions = new GameInput();
        _inputActions.Enable();
        _inputActions.Player.CameraMoveControl.performed += CameraMoveControl_performed;
        _inputActions.Player.CameraMoveControl.canceled += CameraMoveControl_canceled;

        _inputActions.Player.ScreenClick.performed += ScreenClick_performed;
        _inputActions.Player.ScreenClick.canceled += ScreenClick_canceled;
    }

    private void ScreenClick_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _validMove = false;
    }

    private void ScreenClick_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _validMove = true;
    }

    private void CameraMoveControl_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _moveVector = obj.ReadValue<Vector2>();
    }

    private void CameraMoveControl_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _moveVector = obj.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.CameraMoveControl.performed -= CameraMoveControl_performed;
        _inputActions.Player.CameraMoveControl.canceled -= CameraMoveControl_canceled;

        _inputActions.Player.ScreenClick.performed -= ScreenClick_performed;
        _inputActions.Player.ScreenClick.canceled -= ScreenClick_canceled;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(_validMove)
        transform.position += new Vector3(_moveVector.x, 0, _moveVector.y) * movespeeed * Time.deltaTime;

        if (transform.position.z > BoundingBoxLength)
            transform.position = new Vector3(transform.position.x, transform.position.y, BoundingBoxLength);
        if (transform.position.z < -BoundingBoxLength)
            transform.position = new Vector3(transform.position.x, transform.position.y, -BoundingBoxLength);
        if (transform.position.x < -BoundingBoxLength)
            transform.position = new Vector3(-BoundingBoxLength, transform.position.y, transform.position.z);
        if (transform.position.x > BoundingBoxLength)
            transform.position = new Vector3(BoundingBoxLength, transform.position.y, transform.position.z);

    }
}
