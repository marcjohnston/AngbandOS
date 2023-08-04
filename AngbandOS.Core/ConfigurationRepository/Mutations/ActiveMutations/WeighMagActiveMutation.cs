// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class WeighMagActiveMutation : Mutation
{
    private WeighMagActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (SaveGame.CheckIfRacialPowerWorks(6, 6, Ability.Intelligence, 10))
        {
            SaveGame.ReportMagics();
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 6 ? "weigh magic      (unusable until level 6)" : "weigh magic      (cost 6, INT based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You feel you can better understand the magic around you.";
    public override string HaveMessage => "You can feel the strength of the magics affecting you.";
    public override string LoseMessage => "You no longer sense magic.";
}