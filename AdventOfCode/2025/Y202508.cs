using System.Numerics;

namespace AdventOfCode._2025;

public class Y202508 : AoCBase
{
    public override string PartOne(string input)
    {
        // this based on the kruskal algorithm
        var lines = input.ToArrayInput();

        var coords = GetCoords(lines);
        
        // get all box pairs to compare closest for a circuit
        var pairs = GetPairsSortedByDistanceAsc(coords);
        
        var uf = new UnionFind(coords.Count);
        ConnectPairs(uf, pairs);

        var circuitSizes = ComputeCircuitSizes(uf, coords.Count);
        
        var answer = circuitSizes.Values
            .OrderByDescending(v => v)
            .Take(3)
            .Aggregate(1L, (acc, v) => acc * v);

        return answer.ToString();
    }
    
    public override string PartTwo(string input)
    {
        var lines = input.ToArrayInput();
        var coords = GetCoords(lines);
        var pairs = GetPairsSortedByDistanceAsc(coords);
        var uf = new UnionFind(coords.Count);
        
        var junctionBoxCount = coords.Count;
        long answer = 0;
        foreach (var pair in pairs)
        {
            if (junctionBoxCount == 1) break;
    
            // Union returns true when two *different* circuits merge
            if (!uf.Union(pair.indexFirst, pair.indexSecond)) continue;
            
            junctionBoxCount--;
            var boxA = coords[pair.indexFirst];
            var boxB = coords[pair.indexSecond];
            answer = (long)boxA.X * (long)boxB.X;
        }
        
        return answer.ToString();
    }

    private List<Vector3> GetCoords(string[] lines)
    {
        var coords = new List<Vector3>();
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            coords.Add(new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2])));
        }
        return coords;
    }

    private List<(long distance, int indexFirst, int indexSecond)> GetPairsSortedByDistanceAsc(List<Vector3> coords)
    {
        var pairs = new List<(long distance, int indexFirst, int indexSecond)>();
        for (int current = 0; current < coords.Count; current++)
        {
            for (int other = current + 1; other < coords.Count; other++)
            {
                var test = (long)Vector3.DistanceSquared(coords[current], coords[other]);
                pairs.Add((test, current, other));
            }
        }
        
        pairs.Sort((a, b) => 
        {
            var c = a.distance.CompareTo(b.distance);
            if (c != 0) return c;
            c = a.indexFirst.CompareTo(b.indexFirst); // deterministic tiebreaker
            return c != 0 ? c : a.indexSecond.CompareTo(b.indexSecond);
        });
        
        return pairs;
    }

    private void ConnectPairs(UnionFind uf, List<(long distance, int indexFirst, int indexSecond)> pairs)
    {
        // testdata results in 190 pairs. quickfix like this for easy switch between test and real data
        var connectionLimit = pairs.Count == 190 ? 10 : 1000; // 10 for test data, 1000 for real data
        
        // pairs is sorted shortest-first, so we take them in order
        var processed = 0;
        foreach (var pair in pairs)
        {
            // distance is irrelevant since we sorted
            if (processed >= connectionLimit) break;
            processed++;

            uf.Union(pair.indexFirst, pair.indexSecond);
        }
    }
    
    private static Dictionary<int, int> ComputeCircuitSizes(UnionFind uf, int count)
    {
        // Ask every box for its root; boxes sharing a root are one circuit.
        var circuitSizes = new Dictionary<int, int>();
        for (int i = 0; i < count; i++)
        {
            var root = uf.Find(i);
            circuitSizes.TryGetValue(root, out int s);
            circuitSizes[root] = s + 1;
        }
        return circuitSizes;
    }

    private class UnionFind
    {
        private readonly int[] _parent;
        private readonly int[] _size;

        public UnionFind(int count)
        {
            _parent = new int[count];
            _size = new int[count];
            for (int i = 0; i < count; i++)
            {
                _parent[i] = i; // each box starts as its OWN root => its own circuit
                _size[i] = 1; // each circuit currently holds exactly one box
            }
        }

        // Find(x): walk up the parent chain until we reach the root, which circuit does x belong to
        public int Find(int x)
        {
            while (_parent[x] != x)
            {
                _parent[x] = _parent[_parent[x]]; // path compression
                x = _parent[x]; // step up toward the root
            }
            return x;
        }

        // merge the circuits. Attach the smaller tree under the larger
        public bool Union(int a, int b)
        {
            var rootA = Find(a); // root/circuit of box a
            var rootB = Find(b); // root/circuit of box b

            if (rootA == rootB) return false; // same circuit

            if (_size[rootA] < _size[rootB])
                (rootA, rootB) = (rootB, rootA);

            _parent[rootB] = rootA; // box b's whole circuit now points to rootA
            _size[rootA] += _size[rootB]; // box a's circuit grew by box b's member count
            return true;
        }
    }
}