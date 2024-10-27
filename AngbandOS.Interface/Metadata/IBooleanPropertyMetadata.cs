namespace AngbandOS.Core.Interface;

public interface IBooleanPropertyMetadata : IPropertyMetadata
{
    bool? DefaultValue { get; }
}
