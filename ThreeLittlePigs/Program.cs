using System;

class Program
{
    static void Main(string[] args)
    {
        var littlePigs = EstablishProtagonistsWithPreferredBuildingMaterials(typeof(Straw), typeof(Sticks), typeof(Bricks));
        var bigBadWolf = EstablishAntagonist();

        for (int i = 0; i < littlePigs.Length; i++)
        {
            Console.WriteLine();
            littlePigs[i].BuildHouse(i + 1);

            bigBadWolf.Threaten(littlePigs[i]);

            if (littlePigs[i].ResponseToThreat != ThreatResponseAction.LetWolfIn)
            {
                bigBadWolf.Attack(littlePigs[i].House);

                if (littlePigs[i].House.Status == Status.BlownDown)
                {
                    bigBadWolf.Eat(littlePigs[i]);
                }
                else
                {
                    bigBadWolf.ClimbDown(littlePigs[i].House.Chimney);
                    break;
                }
            }
            else
            {
                // Story has taken an unexpected turn.
            }
        }

        Console.WriteLine();
        Console.WriteLine("The End.");
    }

    private static Pig[] EstablishProtagonistsWithPreferredBuildingMaterials(params Type[] buildingtypes)
    {
        Console.WriteLine($"Once upon a time, there were {buildingtypes.Length} little pigs.");

        var pigs = new Pig[buildingtypes.Length];

        for (int i = 0; i < buildingtypes.Length; i++)
        {
            pigs[i] = new Pig(buildingtypes[i]);
        }

        return pigs;
    }

    private static Wolf EstablishAntagonist()
    {
        Console.WriteLine("And, a big bad wolf.");

        return new Wolf();
    }
}

public class Wolf
{
    public Wolf()
    {
    }

    internal void Attack(House house)
    {
        Console.WriteLine("The wolf responded \"Then I'll huff and I'll puff and I'll blow your house in.\"");
        Console.WriteLine("So the wolf huffed and puffed.");
        house.Attack();

    }

    internal void ClimbDown(Chimney chimney)
    {
        Console.WriteLine("So the wolf climbed down the chimney of the house.");
        chimney.ClimbDown(this);
    }

    internal void Eat(Pig pig)
    {
        Console.WriteLine("Then the wolf ate the pig that had been hiding inside.");
    }

    internal void Threaten(Pig pig)
    {
        Console.WriteLine($"The wolf approached the house of the {pig.Size} pig and said \"{pig.Size} pig {pig.Size} pig let me come in.\"");
        pig.Threaten();
    }
}

public class Pig
{
    public Pig(Type preferredBuildingType, PigSize size = PigSize.Little)
    {
        this.ResponseToThreat = ThreatResponseAction.NotSpecified;
        this.PreferredBuildingType = preferredBuildingType;
        this.Size = size;
    }

    public PigSize Size { get; set; }

    public Type PreferredBuildingType { get; }

    public ThreatResponseAction ResponseToThreat { get; internal set; }

    public House House { get; internal set; }

    internal void BuildHouse(int i)
    {
        this.House = new House(PreferredBuildingType);
        Console.WriteLine($"Little pig number {i} built a house out of {PreferredBuildingType}.");
    }

    internal void Threaten()
    {
        Console.WriteLine($"The {Size} pig replied \"Not by the hairs of my chinny chin chin.\"");
        this.ResponseToThreat = ThreatResponseAction.DoNotLetWolfIn;
    }

    public enum PigSize
    {
        Little,
        Medium,
        Big,
    }
}

public class House
{
    private Type buildingType;

    public House(Type buildingType)
    {
        this.Status = Status.StandingFirm;
        this.buildingType = buildingType;
        this.Chimney = new Chimney();
    }

    public Status Status { get; internal set; }

    public Chimney Chimney { get; internal set; }

    internal void Attack()
    {
        if (buildingType != typeof(Bricks))
        {
            Console.WriteLine($"And the house fell down because it was made of {buildingType}.");
            this.Status = Status.BlownDown;
        }
        else
        {
            Console.WriteLine($"But the house stood firm because it was made of {buildingType}.");
        }
    }
}

public enum ThreatResponseAction
{
    NotSpecified,
    LetWolfIn,
    DoNotLetWolfIn
}

public enum Status
{
    Undefined,
    StandingFirm,
    BlownDown,
}

public class Chimney
{
    public void ClimbDown(Wolf wolf)
    {
        Console.WriteLine("The pig heard the wolf on the roof and started a fire which burned up the wolf when he climbed down the chimney.");
    }
}

public class Straw
{
}

public class Sticks
{
}

public class Bricks
{
}