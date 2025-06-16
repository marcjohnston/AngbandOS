// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class Animal1xPet3In5SummonWeightedRandom : SummonWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[] {
        (nameof(AnimalRangerPet1xSummonScript), 3),
        (nameof(Animal1xSummonScript), 2)
    };
    public override string LearnedDetails =>  "control 60%";
}
