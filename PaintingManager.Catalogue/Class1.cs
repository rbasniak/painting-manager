
namespace PaintingManager.Catalogue;

public class Brand
{
    private readonly HashSet<Series>? _series;

    protected Brand()
    {
        
    }

    public Brand(string name)
    {
        Name = Name;

        _series = new HashSet<Series>();
    }

    public string Name { get; set; }
    public IEnumerable<Series>? Series => _series?.ToList();

    internal void AddSeries(Series series)
    {
        if (series.Brand != this)
        {
            throw new InvalidOperationException();
        }

        _series.Add(series);
    }
}

public class Series
{
    private readonly HashSet<Paint>? _paints;

    protected Series()
    {

    }

    public Series(Brand brand, string name)
    {
        Name = Name;
        Brand = brand;

        _paints = new HashSet<Paint>();
    }

    public string Name { get; set; }
    public Brand Brand { get; set; }

    public IEnumerable<Paint>? Paints => _paints?.ToList();

    internal void AddPaint(Paint paint)
    {
        if (paint.Series != this)
        {
            throw new InvalidOperationException();
        }

        _paints.Add(paint);
    }
}

public class Paint
{
    public Paint(Series series, string name, string hexColor, PaintType type)
    {
        Series = series;
        Name = name;
        HexColor = hexColor;
        Type = type;
    }

    public string Name { get; set; }
    public PaintType Type { get; set; }
    public string HexColor { get; set; }
    public Series Series { get; set; }

    public override string ToString()
    {
        return $"[{HexColor}] {Name}";
    }
}

public enum PaintType
{
    Opaque = 0,
    Wash = 1,
    Metalic = 2,
    Transparent = 3,
    Ink = 4
}