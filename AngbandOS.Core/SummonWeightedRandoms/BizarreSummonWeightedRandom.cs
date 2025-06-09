// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SummonWeightedRandoms;

[Serializable]
internal class BizarreSummonWeightedRandom : SummonWeightedRandom
{
    protected BizarreSummonWeightedRandom(Game game) : base(game) { }

    protected override (string name, int weight)[] NameAndWeightBindingTuples => new (string, int)[] {
        (nameof(BizarreAPet1xSummonScript), 1),
        (nameof(BizarreBPet1xSummonScript), 1),
        (nameof(BizarreDPet1xSummonScript), 1),
        (nameof(BizarreEPet1xSummonScript), 1),
        (nameof(BizarreA1xSummonScript), 1),
        (nameof(BizarreB1xSummonScript), 1),
        (nameof(BizarreD1xSummonScript), 1),
        (nameof(BizarreE1xSummonScript), 1),
    };
    public string LearnedDetails =>  "control 50%";
}
