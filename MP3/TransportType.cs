namespace MP3;

public abstract class TransportType  // Klasa abstrakcyjna
{
    public TransportTypeEnum Type { get; }
    public TransportType(TransportTypeEnum type)
    {
        Type = type;
    }
    public abstract string GetTypeOfMovement(); // Polimorficzne wołanie metody
}

public class WaterTransport : TransportType, IWaterTransport // Dziedziczenie
{
    public int VesselDisplacement { get; private set; } = 100;

    public WaterTransport(int displacement) : base(TransportTypeEnum.Water)
    {
        VesselDisplacement = displacement;
    }

    public void SetVesselDisplacement(int displacement) { VesselDisplacement = displacement; }
    public override string GetTypeOfMovement() // Polimorficzne wołanie metody
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
public class AirTransport : TransportType // Dziedziczenie
{
    public AirTransport() : base(TransportTypeEnum.Air) { }

    public override string GetTypeOfMovement() // Polimorficzne wołanie metody
    {
        return $"Move by {Type} Transport";
    }
}

public class Amphibian : GrountTransport, IWaterTransport // Wielodziedziczenie
{
    public WaterTransport waterTransport { get; private set; } // Wielodziedziczenie kompozacja

    public Amphibian(int surfaceContact, string typeOfContact, int displacement) : base(TransportTypeEnum.Amphibian, surfaceContact, typeOfContact)
    {
        waterTransport = new WaterTransport(displacement); // Wielodziedziczenie kompozacja
    }

    public void SetVesselDisplacement(int displacement) { 
        waterTransport.SetVesselDisplacement(displacement);
    }
    public override string GetTypeOfMovement() // Polimorficzne wołanie metody
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