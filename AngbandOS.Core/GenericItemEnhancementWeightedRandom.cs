// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericItemEnhancementWeightedRandom : ItemEnhancementWeightedRandom
{
    public GenericItemEnhancementWeightedRandom(Game game, ItemEnhancementWeightedRandomGameConfiguration itemEnhancementWeightedRandomGameConfiguration) : base(game)
    {
        Key = itemEnhancementWeightedRandomGameConfiguration.Key ?? itemEnhancementWeightedRandomGameConfiguration.GetType().Name;
        ItemEnhancementBindingKeyAndWeightTuples = itemEnhancementWeightedRandomGameConfiguration.ItemEnhancementBindingKeyAndWeightTuples;
    }

    public override string Key { get; }

    protected override (string?, int)[] ItemEnhancementBindingKeyAndWeightTuples { get; }
}

