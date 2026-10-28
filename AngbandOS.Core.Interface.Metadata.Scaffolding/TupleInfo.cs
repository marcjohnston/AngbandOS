namespace AngbandOS.ConfigurationMetadataGenerator;

internal sealed class TupleInfo
{
    public TupleInfo(List<TupleItemInfo> items)
    {
        Items = items;
    }

    public List<TupleItemInfo> Items { get; }
}
