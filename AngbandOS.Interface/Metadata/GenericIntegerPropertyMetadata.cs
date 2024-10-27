namespace AngbandOS.Core.Interface;

public class GenericIntegerPropertyMetadata : GenericPropertyMetadata, IIntegerPropertyMetadata
{
    public int? DefaultValue { get; set; }
}