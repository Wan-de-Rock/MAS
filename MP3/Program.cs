using MP3;

public class Program
{
    public static void Main(string[] args)
    {
        var water = new WaterTransport(200); // Disjoint Inheritance
        var ground = new GrountTransport(TransportTypeEnum.Ground, 50, "Good"); // Disjoint Inheritance
        var air = new AirTransport(); // Disjoint Inheritance
        var amphibian = new Amphibian(40, "Not bad", 152); // Multi inheritance

        /* Multi inheritance */
        Console.WriteLine(amphibian.waterTransport.VesselDisplacement);
        amphibian.SetVesselDisplacement(300);
        Console.WriteLine(amphibian.waterTransport.VesselDisplacement);
        Console.WriteLine(amphibian.TypeOfContact);
        Console.WriteLine(amphibian.SurfaceContact);
        Console.WriteLine(amphibian.GetTypeOfMovement()); // Polimophic method call

        Console.WriteLine("\n/////////////////////////\n");

        /* Dynamic inheritance */
        var dynamic = new DynamicTransport();
        dynamic = DynamicTransport.GetNewDynamicTransport(water.Type);
        Console.WriteLine(dynamic);
        dynamic = DynamicTransport.GetNewDynamicTransport(ground.Type);
        Console.WriteLine(dynamic);
        dynamic.ChangeTransportType(air.Type);
        Console.WriteLine(dynamic);
        dynamic.ChangeTransportType(amphibian.Type);
        Console.WriteLine(dynamic);

        Console.WriteLine("\n/////////////////////////\n");

        /* Overlapping */
        var overlapping = new OverlappingTransport(water.Type);
        overlapping.AddTransportType(air.Type);
        overlapping.AddTransportType(amphibian.Type);
        Console.WriteLine(overlapping);
        overlapping.RemoveTransportType(amphibian.Type);
        Console.WriteLine(overlapping);

        Console.WriteLine("\n/////////////////////////\n");

        /* Multi aspect */
        var multiaspect1 = MultiaspectTransport.CreateAirTypeTransport(TransportTypeEnum.Air);
        var multiaspect2 = new MultiaspectTransportWater("TransportA", 100);
        var multiaspect3 = new MultiaspectTransportAir("TransportB", 10);
        Console.WriteLine(multiaspect1);
        Console.WriteLine(multiaspect2);
        Console.WriteLine(multiaspect3);
    }
}