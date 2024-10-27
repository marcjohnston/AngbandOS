namespace AngbandOS.Core.Interface;

public interface ICollectionPropertyMetadata : IPropertyMetadata
{
    IPropertyMetadata[] PropertyMetadatas { get; }

    string EntityTitle { get; }

    string KeyPropertyName { get; }
}
