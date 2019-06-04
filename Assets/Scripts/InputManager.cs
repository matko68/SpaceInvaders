using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    #region INPUT MANAGER PROPERTY

    private static InputManager _IM;

    public static InputManager IM
    {
        get
        {
            if (_IM == null)
                _IM = FindObjectOfType<InputManager>();
            return _IM;
        }
    }

    #endregion

    public CustomEvent<InputType> InputEvent = new CustomEvent<InputType>();
    public PlayerController Player;
    public ShootingManager PlayerShootingManager;

    private float timer;
    private float delta = 0.015f;
    public float ShootingWaitTime = 0.15f;

    private void Awake()
    {
        if (Player == null) Player = FindObjectOfType<PlayerController>();        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.GM)
            GameManager.GM.ReturnToMenu();

        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = direction.normalized;

        if (Player) Player.Move(direction);

        if (Input.GetKey(KeyCode.Space))
        {

            PlayerShootingManager.SetContinousShooting(true);

            if (Mathf.Abs(timer) < delta)
                PlayerShootingManager.Shoot();

            timer += Time.deltaTime;

            if (timer > ShootingWaitTime)
                timer = 0.0f;

        }

        else
        {
            timer = 0.0f;
            PlayerShootingManager.SetContinousShooting(false);
        }




    }

}