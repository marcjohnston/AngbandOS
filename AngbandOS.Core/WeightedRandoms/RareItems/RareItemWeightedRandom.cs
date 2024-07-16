// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WeightedRandoms;

[Serializable]
internal abstract class RareItemWeightedRandom : WeightedRandom<ItemAdditiveBundle>, IGetKey
{
    protected RareItemWeightedRandom(Game game) : base(game) { }
    protected abstract (string name, int weight)[] ItemFactoryNamesAndWeights { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        foreach ((string name, int weight) in ItemFactoryNamesAndWeights)
        {
            Add(weight, Game.SingletonRepository.Get<ItemAdditiveBundle>(name));
        }
    }

    public string ToJson()
    {
        return "";
    }
}
