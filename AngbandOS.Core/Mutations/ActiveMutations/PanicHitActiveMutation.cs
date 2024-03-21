// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class PanicHitActiveMutation : Mutation
{
    private PanicHitActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(10, 12, Ability.Dexterity, 14))
        {
            return;
        }
        if (!Game.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = Game.MapY + Game.KeypadDirectionYOffset[dir];
        int x = Game.MapX + Game.KeypadDirectionXOffset[dir];
        if (Game.Grid[y][x].MonsterIndex != 0)
        {
            Game.PlayerAttackMonster(y, x);
            Game.RunScriptInt(nameof(TeleportSelfScript), 30);
        }
        else
        {
            Game.MsgPrint("You don't see any monster in this direction");
            Game.MsgPrint(null);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 10 ? "panic hit        (unusable until level 10)" : "panic hit        (cost 12, DEX based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You suddenly understand how thieves feel.";
    public override string HaveMessage => "You can run for your life after hitting something.";
    public override string LoseMessage => "You no longer feel jumpy.";
}