using UnityEngine;

namespace FireBall.Core
{
    public class TagCondition : ConditionBase
    {
        [SerializeField] private string[] _tags;

        public override bool Check(object data = null)
        {
            if (data is Collision collision)
            {
                foreach (var tag in _tags)
                {
                    if (collision.gameObject.tag == tag)
                        return true;
                }
                return false;
            }

            if (data is AnimExecutorOnPhysics.AnimationForExecute animInformation)
            {
                foreach (var tag in _tags)
                {
                    if(animInformation.Collision.gameObject.tag == tag)
                        return true;
                }
                return false;
            }

            return false;
        }
    }
}