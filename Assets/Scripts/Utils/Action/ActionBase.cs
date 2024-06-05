using System;
using UnityEngine;

namespace FireBall.Core
{
    public abstract class ActionBase : MonoBehaviour
    {
        public abstract void Execute(object data = null);
    }
}
