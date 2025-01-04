// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AncientDragonSummonWeightedRandom : SummonWeightedRandom
{
    protected AncientDragonSummonWeightedRandom(Game game) : base(game) { }

    protected override (string name, int weight)[] NameAndWeightBindingTuples => new (string, int)[] {
        (nameof(AncientDragonPet1xSummonScript), 6),
        (nameof(AncientDragon1xSummonScript), 4)
    };
}
