namespace UnitTests;

public class DictionaryComparer : IEqualityComparer<Dictionary<string, string>>
{
    public bool Equals(Dictionary<string, string> x, Dictionary<string, string> y)
    {
        if (x == null || y == null)
        {
            return false;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        foreach (var kvp in x)
        {
            if (!y.TryGetValue(kvp.Key, out var value))
            {
                return false;
            }

            if (kvp.Value != value)
            {
                return false;
            }
        }

        return true;
    }

    public int GetHashCode(Dictionary<string, string> obj)
    {
        unchecked
        {
            int hash = 17;
            foreach (var kvp in obj)
            {
                hash = hash * 23 + kvp.Key.GetHashCode();
            }
            return hash;
        }
    }
}
