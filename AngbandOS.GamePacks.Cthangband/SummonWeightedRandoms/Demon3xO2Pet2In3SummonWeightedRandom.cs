// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Demon3xO2Pet2In3SummonWeightedRandom : SummonWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[] {
        (nameof(DemonPet3xO2SummonScript), 2),
        (nameof(Demon3xO2SummonScript), 1)
    };
    public override string LearnedDetails =>  "control 67%";
}
