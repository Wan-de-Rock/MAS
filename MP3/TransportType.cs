
namespace MP3
{
    public abstract class TransportType 
    {
        public TransportTypeEnum Type { get; }
        public TransportType(TransportTypeEnum type)
        {
            Type = type;
        }
        public abstract string GetTypeOfMovement();
    }

    public class WaterTransport : TransportType, IWaterTransport
    {
        public int VesselDisplacement { get; private set; } = 100;

        public WaterTransport(int displacement) : base(TransportTypeEnum.Water)
        {
            VesselDisplacement = displacement;
        }

        public void SetVesselDisplacement (int displacement) { VesselDisplacement = displacement; }
        public override string GetTypeOfMovement()
        {
            return $"Move by {Type} Transport";
        }
    }
    public class GrountTransport : TransportType
    {
        public int SurfaceContact { get; set; } = 150;
        public string TypeOfContact { get; }

        public GrountTransport(TransportTypeEnum type, int surfaceContact, string typeOfContact) : base(type)
        {
            SurfaceContact = surfaceContact;
            TypeOfContact = typeOfContact;
        }

        public override string GetTypeOfMovement()
        {
            return $"Move by {Type} Transport";
        }
    }
    public class AirTransport : TransportType
    {
        public AirTransport() : base(TransportTypeEnum.Air)
        {
        }

        public override string GetTypeOfMovement()
        {
            return $"Move by {Type} Transport";
        }
    }

    public interface IWaterTransport
    {
        void SetVesselDisplacement(int displacement);
        string GetTypeOfMovement();
    }

    public class Amphibian : GrountTransport, IWaterTransport
    {
        public int VesselDisplacement { get; private set; } = 100;

        public Amphibian(int surfaceContact, string typeOfContact, int displacement) : base(TransportTypeEnum.Amphibian, surfaceContact, typeOfContact)
        {
            VesselDisplacement = displacement;
        }

        public void SetVesselDisplacement(int displacement) { VesselDisplacement = displacement; }
        public override string GetTypeOfMovement()
        {
            return $"Move by {Type}";
        }

    }


    public enum TransportTypeEnum
    {
        Water,
        Ground,
        Air,
        Amphibian
    }

    //public abstract class TransportBase : Transport { }

}
