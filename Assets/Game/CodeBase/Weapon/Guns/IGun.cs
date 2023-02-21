﻿using UnityEngine;

namespace Game.CodeBase.Weapon.Guns
{
    public interface IGun
    {
        void Shoot(Vector3 direction);
        void Reload();

        void ChangeGun();
    }
}