using MP3;

var water = new WaterTransport(200);
var ground = new GrountTransport(TransportTypeEnum.Ground, 50, "Good");
var air = new AirTransport();
var amphibian = new Amphibian(40, "Not bad", 152); // wielodzidziczenie

/* wielodzidziczenie */
Console.WriteLine(amphibian.waterTransport.VesselDisplacement);
amphibian.SetVesselDisplacement(300);
Console.WriteLine(amphibian.waterTransport.VesselDisplacement);
Console.WriteLine(amphibian.TypeOfContact);
Console.WriteLine(amphibian.SurfaceContact);
Console.WriteLine(amphibian.GetTypeOfMovement());

Console.WriteLine("\n/////////////////////////\n");

/* Dzidziczenie Dynamiczne */
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

/* Wieloaspektowe */
var multiaspect1 = new MultiaspectTransport(10, 20, TransportTypeEnum.Water);
var multiaspect2 = MultiaspectTransport.CreateTransportA(15, 20);
var multiaspect3 = new TransportB(multiaspect1, "TransportB");
Console.WriteLine(multiaspect1);
Console.WriteLine(multiaspect2);
Console.WriteLine(multiaspect3);