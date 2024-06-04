// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundleWeightedRandoms;

[Serializable]
internal abstract class BoundItemAdditiveBundleWeightedRandom : ItemAdditiveBundleWeightedRandom, IGetKey
{
    protected BoundItemAdditiveBundleWeightedRandom(Game game) : base(game) { }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    protected abstract (string, int)[] ItemAdditiveBundleNames { get; }

    public virtual void Bind()
    {
        foreach ((string itemAdditiveBundleName, int weight) in ItemAdditiveBundleNames)
        {
            Add(weight, Game.SingletonRepository.Get<ItemAdditiveBundle>(itemAdditiveBundleName));
        }
    }

    public string ToJson()
    {
        return "";
    }
}
