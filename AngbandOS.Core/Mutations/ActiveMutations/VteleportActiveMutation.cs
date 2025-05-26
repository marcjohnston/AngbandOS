// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class VteleportActiveMutation : Mutation
{
    private VteleportActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(7, 7, Game.WisdomAbility, 15))
        {
            return;
        }
        Game.MsgPrint("You concentrate...");
        Game.RunScriptInt(nameof(TeleportSelfScript), 10 + (4 * Game.ExperienceLevel.IntValue));
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "teleport         (unusable until level 7)" : "teleport         (cost 7, WIS based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the power of teleportation at will.";
    public override string HaveMessage => "You can teleport at will.";
    public override string LoseMessage => "You lose the power of teleportation at will.";
}