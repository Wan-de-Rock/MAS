using MP3;


// Multy / Abstract
var water = new WaterTransport(200);
var ground = new GrountTransport(TransportTypeEnum.Ground, 50, "Good");
var air = new AirTransport();
var amphibian = new Amphibian(40, "Not bad", 152);

Console.WriteLine(amphibian.VesselDisplacement);
amphibian.SetVesselDisplacement(300);
Console.WriteLine(amphibian.VesselDisplacement);
Console.WriteLine(amphibian.TypeOfContact);
Console.WriteLine(amphibian.SurfaceContact);
Console.WriteLine(amphibian.GetTypeOfMovement());

Console.WriteLine("\n/////////////////////////\n");

var dynamic = new DynamicTransport();
dynamic = dynamic.ChangeTransportType(water.Type);
Console.WriteLine(dynamic);
dynamic = dynamic.ChangeTransportType(ground.Type);
Console.WriteLine(dynamic);
dynamic = dynamic.ChangeTransportType(air.Type);
Console.WriteLine(dynamic);
dynamic = dynamic.ChangeTransportType(amphibian.Type);
Console.WriteLine(dynamic);

Console.WriteLine("\n/////////////////////////\n");

var overlapping = new OverlappingTransport(water.Type);
overlapping.AddTransportType(air.Type);
overlapping.AddTransportType(amphibian.Type);
Console.WriteLine(overlapping);
overlapping.RemoveTransportType(amphibian.Type);
Console.WriteLine(overlapping);

Console.WriteLine("\n/////////////////////////\n");

var multiaspect = new MultiaspectTransport(10, 20, TransportTypeEnum.Water);
var multiaspect1 = MultiaspectTransport.CreateTransportA(15, 20);
var multiaspect2 = new TransportB(multiaspect1, "TransportB");
Console.WriteLine(multiaspect);
Console.WriteLine(multiaspect1);
Console.WriteLine(multiaspect2);