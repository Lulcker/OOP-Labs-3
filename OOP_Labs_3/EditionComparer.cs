namespace OOP_Labs_3;

class EditionComparer : IComparer<Edition>
{
    public int Compare(Edition x, Edition y)
    {
        return x.Circulation.CompareTo(y.Circulation);
    }
}