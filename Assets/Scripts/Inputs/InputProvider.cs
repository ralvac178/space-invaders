
using UnityEngine;

public static class InputProvider
{
    public delegate void OnShoot();
    public static event OnShoot OnHasShoot;

    public delegate void OnMove(Vector3 direction);
    public static event OnMove OnHasMove;

    public static void Shoot()
    {
        OnHasShoot?.Invoke();
    }

    public static void Move(Vector3 direction)
    {
        OnHasMove?.Invoke(direction);
    }
}
