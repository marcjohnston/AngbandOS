namespace AngbandOS.Core;

/// <summary>
/// Represents the interface that a repository item can implement to support the SingletonRepository.WeightedShuffle.  Weighted shuffles sort the items by weight, 
/// with the highest weight first and all items of the same weight are shuffled amongst themselves.  The 
/// </summary>
internal interface IWeightedShuffle
{
    /// <summary>
    /// Represents the weight to assign for the item.  A higher weight will be placed at a lower index than items with a lower weight.  Items with the same weights are randomly
    /// shuffled amongst themselves.
    /// </summary>
    int ShuffleWeight { get; }
}