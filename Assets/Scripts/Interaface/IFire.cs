using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IFire
    {
        void Fire(Rigidbody2D bullet);
    }
}