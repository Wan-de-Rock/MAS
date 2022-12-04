namespace MP3;

public class DynamicTransport
{
    public bool canSwim { get; private set; }
    public bool canDrive { get; private set; }
    public bool canFly { get; private set; }

    public TransportTypeEnum TransportType { get; private set; }

    public void ChangeTransportType(TransportTypeEnum transportType)
    {
        TransportType = transportType;

        switch (transportType)
        {
            case TransportTypeEnum.Water:
                canSwim = true;
                canDrive = false;
                canFly = false;
                break;
            case TransportTypeEnum.Ground:
                canSwim = false;
                canDrive = true;
                canFly = false;
                break;
            case TransportTypeEnum.Air:
                canSwim = false;
                canDrive = false;
                canFly = true;
                break;
            case TransportTypeEnum.Amphibian:
                canSwim = true;
                canDrive = true;
                canFly = false;
                break;
            default:
                break;
        }
    }

    public static DynamicTransport GetNewDynamicTransport(TransportTypeEnum transportType)
    {
        var res = new DynamicTransport();
        res.TransportType = transportType;

        switch (transportType)
        {
            case TransportTypeEnum.Water:
                res.canSwim = true;
                res.canDrive = false;
                res.canFly = false;
                break;
            case TransportTypeEnum.Ground:
                res.canSwim = false;
                res.canDrive = true;
                res.canFly = false;
                break;
            case TransportTypeEnum.Air:
                res.canSwim = false;
                res.canDrive = false;
                res.canFly = true;
                break;
            case TransportTypeEnum.Amphibian:
                res.canSwim = true;
                res.canDrive = true;
                res.canFly = false;
                break;
            default:
                break;
        }

        return res;
    }

    public override string? ToString()
    {
        return $"Can swim: {canSwim}, Can drive: {canDrive}, Can fly: {canFly}";
    }
}

public class OverlappingTransport
{
    public bool canSwim { get; private set; }
    public bool canDrive { get; private set; }
    public bool canFly { get; private set; }

    private List<TransportTypeEnum> transportTypes;

    public OverlappingTransport(TransportTypeEnum type)
    {
        transportTypes = new List<TransportTypeEnum>();
        transportTypes.Add(type);
    }

    public void AddTransportType(TransportTypeEnum transportType)
    {
        if (!transportTypes.Contains(transportType))
        {
            transportTypes.Add(transportType);

            switch (transportType)
            {
                case TransportTypeEnum.Water:
                    canSwim = true;
                    break;
                case TransportTypeEnum.Ground:
                    canDrive = true;
                    break;
                case TransportTypeEnum.Air:
                    canFly = true;
                    break;
                case TransportTypeEnum.Amphibian:
                    canSwim = true;
                    canDrive = true;
                    break;
                default:
                    break;
            }
        }
    }
    public void RemoveTransportType(TransportTypeEnum transportType)
    {
        if (transportTypes.Contains(transportType))
        {
            switch (transportType)
            {
                case TransportTypeEnum.Water:
                    if (!transportTypes.Contains(TransportTypeEnum.Amphibian))
                        canSwim = false;
                    break;
                case TransportTypeEnum.Ground:
                    if (!transportTypes.Contains(TransportTypeEnum.Amphibian))
                        canDrive = false;
                    break;
                case TransportTypeEnum.Air:
                    canFly = false;
                    break;
                case TransportTypeEnum.Amphibian:
                    if (!transportTypes.Contains(TransportTypeEnum.Water))
                        canSwim = false;
                    if (!transportTypes.Contains(TransportTypeEnum.Ground))
                        canDrive = false;
                    break;
                default:
                    break;
            }
        }
        else
            throw new ArgumentException("Transport doesn't include this type");
    }

    public override string? ToString()
    {
        return $"Can swim: {canSwim}, Can drive: {canDrive}, Can fly: {canFly}";
    }
}

public class MultiaspectTransport
{
    public int Power { get; }
    public int Fuel { get; }
    public TransportTypeEnum TransportType { get; private set; }

    private MultiaspectTransport(int power, int fuel)
    {
        Power = power;
        Fuel = fuel;
    }
    public MultiaspectTransport(int power, int fuel, TransportTypeEnum transportType)
    {
        Power = power;
        Fuel = fuel;
        TransportType = transportType;
    }

    public static MultiaspectTransport CreateTransportA(int power, int fuel)
    {
        var transport = new MultiaspectTransport(power, fuel);
        transport.TransportType = TransportTypeEnum.Air;

        return transport;
    }
    public override string ToString()
    {
        return $"Power: {Power}, Fuel: {Fuel}, Type: {TransportType}";
    }
}

public class TransportB : MultiaspectTransport // Multiaspect
{
    public string Name { get; }
    public TransportB(MultiaspectTransport multiaspectTransport, string name) : base(multiaspectTransport.Power, multiaspectTransport.Fuel, multiaspectTransport.TransportType)
    {
        Name = name;
    }

    public override string ToString()
    {
        return base.ToString() + $", Name: {Name}";
    }
}