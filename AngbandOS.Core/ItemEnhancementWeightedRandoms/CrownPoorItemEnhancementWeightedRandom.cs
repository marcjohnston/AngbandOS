// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancementWeightedRandoms;

[Serializable]
internal class CrownPoorItemEnhancementWeightedRandom : ItemEnhancementWeightedRandom
{
    private CrownPoorItemEnhancementWeightedRandom(Game game) : base(game) { } // This object is a singleton.
    protected override (string?, int)[] ItemEnhancementBindingKeyAndWeightTuples => new (string?, int)[]
    {
        (nameof(HatOfStupidityItemEnhancement), 2),
        (nameof(HatOfNaivetyItemEnhancement), 2),
        (nameof(HatOfUglinessItemEnhancement), 1),
        (nameof(HatOfSicklinessItemEnhancement), 1),
        (nameof(HatOfTeleportationItemEnhancement), 1)
    };
}
