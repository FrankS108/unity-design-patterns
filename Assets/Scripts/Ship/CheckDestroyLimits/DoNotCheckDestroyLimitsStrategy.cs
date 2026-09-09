using UnityEngine;

namespace Ships.CheckDestroyLimits
{
    public class DoNotCheckDestroyLimitsStrategy : CheckDestroyLimits
    {
        public bool isInsideTheLimits(Vector3 position)
        {
            return true;
        }
    }
}