namespace Patterns.Mediator
{
    public interface Vehicle
    {
        void BrakePressed();
        void BrakeRelease();
        void LeftPressed();
        void ObstacleDetected();
        void RightPressed();
    }
}