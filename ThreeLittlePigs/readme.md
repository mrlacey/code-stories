# Three Little Pigs

Code can be used to tell the story:

```cs
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
```

And that code also produces something in a more familiar format.

```ascii
Once upon a time, there were 3 little pigs.
And, a big bad wolf.

Little pig number 1 built a house out of Straw.
The wolf approached the house of the Little pig and said "Little pig Little pig let me come in."
The Little pig replied "Not by the hairs of my chinny chin chin."
The wolf responded "Then I'll huff and I'll puff and I'll blow your house in."
So the wolf huffed and puffed.
And the house fell down because it was made of Straw.
Then the wolf ate the pig that had been hiding inside.

Little pig number 2 built a house out of Sticks.
The wolf approached the house of the Little pig and said "Little pig Little pig let me come in."
The Little pig replied "Not by the hairs of my chinny chin chin."
The wolf responded "Then I'll huff and I'll puff and I'll blow your house in."
So the wolf huffed and puffed.
And the house fell down because it was made of Sticks.
Then the wolf ate the pig that had been hiding inside.

Little pig number 3 built a house out of Bricks.
The wolf approached the house of the Little pig and said "Little pig Little pig let me come in."
The Little pig replied "Not by the hairs of my chinny chin chin."
The wolf responded "Then I'll huff and I'll puff and I'll blow your house in."
So the wolf huffed and puffed.
But the house stood firm because it was made of Bricks.
So the wolf climbed down the chimney of the house.
The pig heard the wolf on the roof and started a fire which burned up the wolf when he climbed down the chimney.

The End.
```
