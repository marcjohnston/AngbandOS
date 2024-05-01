// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class RteleportRandomMutation : Mutation
{
    private RteleportRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your position seems very uncertain...";
    public override string HaveMessage => "You are teleporting randomly.";
    public override string LoseMessage => "Your position seems more certain.";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(5000) != 88)
        {
            return;
        }
        if (Game.HasNexusResistance || Game.HasAntiTeleport)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("Your position suddenly seems very uncertain...");
        Game.MsgPrint(null);
        Game.RunScriptInt(nameof(TeleportSelfScript), 40);
    }
}