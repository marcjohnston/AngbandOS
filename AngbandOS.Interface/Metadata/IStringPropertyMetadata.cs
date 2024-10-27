namespace AngbandOS.Core.Interface;

public interface IStringPropertyMetadata : IPropertyMetadata
{
    string? DefaultValue { get; }
}
