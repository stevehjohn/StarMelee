namespace StarMelee.GameElements
{
    public class ShipProperties
    {
        public float TurnDelta { get; }

        public float Acceleration { get; set; }

        public float Deceleration { get; set; }

        public float MaxSpeed { get; set; }

        public ShipProperties()
        {
            TurnDelta = 0.1f;
        }
    }
}