using UnityEngine;
namespace Ships.CheckLimits
{
    class ViewportCheckLimits : CheckLimits
    {
        [SerializeField] private float minScreen = 0.03f;
        [SerializeField] private float maxScreen = 0.97f;
        private readonly Camera camera;

        public ViewportCheckLimits(Camera camera)
        {
            this.camera = camera;
        }

        public Vector2 ClampFinalPosition(Vector2 currentPosition)
        {
            Vector3 viewportPoint = camera.WorldToViewportPoint(currentPosition);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, minScreen, maxScreen);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, minScreen, maxScreen);
            return camera.ViewportToWorldPoint(viewportPoint);
        }
    }

}