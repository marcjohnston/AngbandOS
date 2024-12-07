// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
internal abstract class ItemEnhancementWeightedRandom : WeightedRandom<ItemEnhancement?>, IGetKey
{
    protected ItemEnhancementWeightedRandom(Game game) : base(game) { }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    protected abstract (string?, int)[] ItemEnhancementBindingKeyAndWeightTuples { get; }

    public virtual void Bind()
    {
        foreach ((string? itemEnhancementBindingKey, int weight) in ItemEnhancementBindingKeyAndWeightTuples)
        {
            Add(weight, Game.SingletonRepository.GetNullable<ItemEnhancement>(itemEnhancementBindingKey));
        }
    }

    public string ToJson()
    {
        return "";
    }
}
