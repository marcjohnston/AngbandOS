// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationWeighMag : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (saveGame.CheckIfRacialPowerWorks(6, 6, Ability.Intelligence, 10))
        {
            saveGame.ReportMagics();
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 6 ? "weigh magic      (unusable until level 6)" : "weigh magic      (cost 6, INT based)";
    }

    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "You feel you can better understand the magic around you.";
        HaveMessage = "You can feel the strength of the magics affecting you.";
        LoseMessage = "You no longer sense magic.";
    }
}