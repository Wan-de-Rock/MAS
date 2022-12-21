namespace MP3;

public abstract class TransportType  // Abstract class
{
    public TransportTypeEnum Type { get; }
    public TransportType(TransportTypeEnum type)
    {
        Type = type;
    }
    public abstract string GetTypeOfMovement(); // Polimophic method call
}

public class WaterTransport : TransportType, IWaterTransport // Inheritance
{
    public int VesselDisplacement { get; private set; } = 100;

    public WaterTransport(int displacement) : base(TransportTypeEnum.Water)
    {
        VesselDisplacement = displacement;
    }

    public void SetVesselDisplacement(int displacement) { VesselDisplacement = displacement; }
    public override string GetTypeOfMovement() // Polimophic method call
    {
        return $"Move by {Type} Transport";
    }
}
public class GrountTransport : TransportType // Dziedziczenie
{
    public int SurfaceContact { get; set; } = 150;
    public string TypeOfContact { get; }

    public GrountTransport(TransportTypeEnum type, int surfaceContact, string typeOfContact) : base(type)
    {
        SurfaceContact = surfaceContact;
        TypeOfContact = typeOfContact;
    }

    public override string GetTypeOfMovement() // Polimorficzne wołanie metody
    {
        return $"Move by {Type} Transport";
    }
}
public class AirTransport : TransportType // Inheritance
{
    public AirTransport() : base(TransportTypeEnum.Air) { }

    public override string GetTypeOfMovement() // Polimophic method call
    {
        return $"Move by {Type} Transport";
    }
}

public class Amphibian : GrountTransport, IWaterTransport // Multi inheritance
{
    public WaterTransport waterTransport { get; private set; } // Multi inheritance composition

    public Amphibian(int surfaceContact, string typeOfContact, int displacement) : base(TransportTypeEnum.Amphibian, surfaceContact, typeOfContact)
    {
        waterTransport = new WaterTransport(displacement); // Multi inheritance composition
    }

    public void SetVesselDisplacement(int displacement) { 
        waterTransport.SetVesselDisplacement(displacement);
    }
    public override string GetTypeOfMovement() // Polimophic method call
    {
        return $"Move by {Type}";
    }

    public override string ToString()
    {
        return $"Surface contact: {SurfaceContact} Type of contact:{TypeOfContact} Vessel displacement: {waterTransport.VesselDisplacement}";
    }
}

public interface IWaterTransport
{
    void SetVesselDisplacement(int displacement);
}

public enum TransportTypeEnum
{
    Water,
    Ground,
    Air,
    Amphibian
}