using System.Numerics;

namespace AdventOfCode._2025;

public class Y202507 : AoCBase
{
    private const char Start = 'S';
    private const char Splitter = '^';
    private const char Beam = '|';
    
    public override int PartOne(string input)
    {
        var lines = input.ToEnumerableString().ToArray();
        var splitHitCount = 0;

        // hashset to prevent duplicate beam index and double counting
        var beamIndexArray = new HashSet<int>();
        
        // beam start from S, which is the on the first line and flows to the same index below
        var beamIndexStart = lines[0].IndexOf(Start, StringComparison.Ordinal);
        beamIndexArray.Add(beamIndexStart);

        for (var i = 1; i < lines.Length; i++)
        {
            foreach (var beam in beamIndexArray.ToList())
            {
                if (lines[i][beam] == Splitter)
                {
                    splitHitCount++;
                    beamIndexArray.Remove(beam);
                    beamIndexArray.Add(beam+1);
                    beamIndexArray.Add(beam-1);
                    
                    ReplaceWithBeam(ref lines, i, beam, true);
                }
                else
                {
                    ReplaceWithBeam(ref lines, i, beam, false);
                }
            }
        }

        return splitHitCount;
    }

    private static void ReplaceWithBeam(ref string[] lines, int lineIndex, int beam, bool isSplitter)
    {
        var chars = lines[lineIndex].ToCharArray();
        if (isSplitter)
        {
            chars[beam+1] = Beam;
            chars[beam-1] = Beam;
        }
        else
        {
            chars[beam] = Beam;
        }
        lines[lineIndex] = new string(chars);
    }
}