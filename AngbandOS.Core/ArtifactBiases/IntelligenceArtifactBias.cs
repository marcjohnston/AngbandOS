// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class IntelligenceArtifactBias : ArtifactBias
{
    private IntelligenceArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Intelligence";

    public override bool ApplyRandomArtifactBonuses(RandomArtifactCharacteristics characteristics)
    {
        if (!characteristics.Int)
        {
            characteristics.Int = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(RandomArtifactCharacteristics characteristics)
    {
        if (!characteristics.SustInt)
        {
            characteristics.SustInt = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
}
