using AdventOfCode._2023;

namespace AdventOfCodeTests;

[TestFixture]
public class Y2023Tests
{
    [OneTimeSetUp]
    public void Init() { }

    [OneTimeTearDown]
    public void Cleanup() { }

    #region Day 1
    [Test]
    public void Y202301_PartOne()
    {
        var aoc = new Y202301();
        var input = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
        var result = aoc.PartOne(input);
        Assert.That(result, Is.EqualTo(142));
    }
    
    [Test]
    public void Y202301_PartTwo()
    {
        var aoc = new Y202301();
        var input = "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";
        var result = aoc.PartTwo(input);
        Assert.That(result, Is.EqualTo(281));
    }
    #endregion

    #region Day 2
    [Test]
    public void Y202302_PartOne()
    {
        var aoc = new Y202302();
        var input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        var result = aoc.PartOne(input);
        Assert.That(result, Is.EqualTo(8));
    }
    
    [Test]
    public void Y202302_PartTwo()
    {
        var aoc = new Y202302();
        var input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        var result = aoc.PartTwo(input);
        Assert.That(result, Is.EqualTo(2286));
    }
    #endregion
    
    #region Day 3
    [Test]
    public void Y202303_PartOne()
    {
        var aoc = new Y202303();
        var input = "467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..";
        var result = aoc.PartOne(input);
        Assert.That(result, Is.EqualTo(4361));
    }
    
    [Test]
    public void Y202303_PartTwo()
    {
        var aoc = new Y202303();
        var input = "467..114..\n...*......\n..35..633.\n......#...\n617*......\n.....+.58.\n..592.....\n......755.\n...$.*....\n.664.598..";
        var result = aoc.PartTwo(input);
        Assert.That(result, Is.EqualTo(467835));
    }
    #endregion
    
    #region Day 4
    [Test]
    public void Y202304_PartOne()
    {
        var aoc = new Y202304();
        var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
        var result = aoc.PartOne(input);
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void Y202304_PartTwo()
    {
        var aoc = new Y202304();
        var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
        var result = aoc.PartTwo(input);
        Assert.That(result, Is.EqualTo(30));
    }
    #endregion
    
    #region Day 5
    [Test]
    public void Y202305_PartOne()
    {
        var aoc = new Y202305();
        var input = "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4";
        var result = aoc.PartOne(input);
        Assert.That(result, Is.EqualTo(35));
    }
    
    [Test]
    public void Y202305_PartTwo()
    {
        var aoc = new Y202305();
        var input = "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37\n56 93 4";
        var result = aoc.PartTwo(input);
        Assert.That(result, Is.EqualTo(46));
    }
    #endregion
    
    #region Day 6
    [Test]
    public void Y202306_PartOne()
    {
        var aoc = new Y202306();
        var input = "Time:      7  15   30\nDistance:  9  40  200";
        var result = aoc.PartOne(input);
        Assert.That(result, Is.EqualTo(288));
    }
    
    [Test]
    public void Y202306_PartTwo()
    {
        var aoc = new Y202306();
        var input = "";
        var result = aoc.PartTwo(input);
        Assert.That(result, Is.EqualTo(0));
    }
    #endregion
}