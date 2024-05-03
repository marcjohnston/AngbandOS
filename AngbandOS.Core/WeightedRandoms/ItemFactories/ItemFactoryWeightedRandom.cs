﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WeightedRandoms;

[Serializable]
internal abstract class ItemFactoryWeightedRandom : WeightedRandom<ItemFactory>, IGetKey
{
    protected ItemFactoryWeightedRandom(Game game) : base(game) { } 
    protected abstract (string name, int weight)[] ItemFactoryNamesAndWeights { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        List<(ItemFactory itemFactory, int weight)> itemFactoriesAndWeightsList = new List<(ItemFactory itemFactory, int weight)>();
        foreach ((string name, int weight) in ItemFactoryNamesAndWeights)
        {
            Add(weight, Game.SingletonRepository.Get<ItemFactory>(name));
        }
    }

    public string ToJson()
    {
        return "";
    }
}
