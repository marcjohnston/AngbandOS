namespace AngbandOS.Core.Interface;

public interface IIntegerPropertyMetadata : IPropertyMetadata
{
    public int? DefaultValue { get; }
}
