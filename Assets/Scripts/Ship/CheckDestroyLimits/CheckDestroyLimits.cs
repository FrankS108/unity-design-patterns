using UnityEngine;

namespace Ships.CheckDestroyLimits
{
     public interface CheckDestroyLimits
     {
          bool isInsideTheLimits(Vector3 position);
     }
}