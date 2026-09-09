using UnityEngine;

namespace Ships.CheckDestroyLimits
{
     public class CheckBottomLimitsStrategy : CheckDestroyLimits
     {
          private readonly Camera camera;

          public CheckBottomLimitsStrategy(Camera camera)
          {
               this.camera = camera;
          }
          public bool isInsideTheLimits(Vector3 position)
          {
               Vector3 viewportPoint = camera.WorldToViewportPoint(position);
               return viewportPoint.y > 0;
          }
     }
}