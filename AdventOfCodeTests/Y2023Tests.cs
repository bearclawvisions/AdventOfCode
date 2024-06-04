using AdventOfCode;
using AdventOfCode._2023;

namespace AdventOfCodeTests;

[TestFixture]
public class Y2023Tests()
{
    private IHelper helper;
    
    [OneTimeSetUp]
    public void Init() { helper = new Helper(); }

    [OneTimeTearDown]
    public void Cleanup() {  }

    #region Day 1
    [Test]
    public void Y202301_PartOne()
    {
        var y202301 = new Y202301(helper);
        var input = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        var result = y202301.PartOne(input);
        Assert.That(result, Is.EqualTo(142));
    }
    
    [Test]
    public void Y202301_PartTwo()
    {
        var y202301 = new Y202301(helper);
        var input = new List<string>
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        var result = y202301.PartTwo(input);
        Assert.That(result, Is.EqualTo(281));
    }
    #endregion

    #region Day 2
    [Test]
    public void Y202302_PartOne()
    {
        var y202302 = new Y202302(helper);
        var input = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };
        var result = y202302.PartOne(input);
        Assert.That(result, Is.EqualTo(8));
    }
    
    [Test]
    public void Y202302_PartTwo()
    {
        var y202302 = new Y202302(helper);
        var input = new List<string>
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };
        var result = y202302.PartTwo(input);
        Assert.That(result, Is.EqualTo(2286));
    }
    #endregion
    
    #region Day 3
    [Test]
    public void Y202303_PartOne()
    {
        var y202303 = new Y202303(helper);
        var input = new List<string>
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var result = y202303.PartOne(input);
        Assert.That(result, Is.EqualTo(4361));
    }
    
    [Test]
    public void Y202303_PartTwo()
    {
        var y202303 = new Y202303(helper);
        var input = new List<string>
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };
        var result = y202303.PartTwo(input);
        Assert.That(result, Is.EqualTo(467835));
    }
    #endregion
    
    #region Day 4
    [Test]
    public void Y202304_PartOne()
    {
        var y202304 = new Y202304(helper);
        var input = new List<string>
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };
        var result = y202304.PartOne(input);
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void Y202304_PartTwo()
    {
        var y202304 = new Y202304(helper);
        var input = new List<string>
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };
        var result = y202304.PartTwo(input);
        Assert.That(result, Is.EqualTo(30));
    }
    #endregion
    
    #region Day 5
    [Test]
    public void Y202305_PartOne()
    {
        var y202305 = new Y202305(helper);
        var input = "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4";
        var result = y202305.PartOne(input);
        Assert.That(result, Is.EqualTo(35));
    }
    
    [Test]
    public void Y202305_PartTwo()
    {
        var y202305 = new Y202305(helper);
        var input = "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4";
        var result = y202305.PartTwo(input);
        Assert.That(result, Is.EqualTo(46));
    }
    #endregion
}