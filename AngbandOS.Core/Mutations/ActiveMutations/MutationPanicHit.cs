// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationPanicHit : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(10, 12, Ability.Dexterity, 14))
        {
            return;
        }
        if (!saveGame.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
        int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
        if (saveGame.Level.Grid[y][x].MonsterIndex != 0)
        {
            saveGame.PlayerAttackMonster(y, x);
            saveGame.TeleportPlayer(30);
        }
        else
        {
            saveGame.MsgPrint("You don't see any monster in this direction");
            saveGame.MsgPrint(null);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 10 ? "panic hit        (unusable until level 10)" : "panic hit        (cost 12, DEX based)";
    }

    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "You suddenly understand how thieves feel.";
        HaveMessage = "You can run for your life after hitting something.";
        LoseMessage = "You no longer feel jumpy.";
    }
}