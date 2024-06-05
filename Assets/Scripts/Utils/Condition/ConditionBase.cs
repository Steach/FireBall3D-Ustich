using System;
using UnityEngine;

namespace FireBall.Core
{
    public abstract class ConditionBase : MonoBehaviour
    {
        public abstract bool Check(object data = null);
    }
}