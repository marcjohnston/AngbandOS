// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationBanish : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(25, 25, Ability.Wisdom, 18))
        {
            return;
        }
        if (!saveGame.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[dir];
        int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[dir];
        GridTile cPtr = saveGame.Level.Grid[y][x];
        if (cPtr.MonsterIndex == 0)
        {
            saveGame.MsgPrint("You sense no evil there!");
            return;
        }
        Monster mPtr = saveGame.Level.Monsters[cPtr.MonsterIndex];
        MonsterRace rPtr = mPtr.Race;
        if (rPtr.Evil)
        {
            saveGame.Level.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
            saveGame.MsgPrint("The evil creature vanishes in a puff of sulfurous smoke!");
        }
        else
        {
            saveGame.MsgPrint("Your invocation is ineffectual!");
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 25 ? "banish evil      (unusable until level 25)" : "banish evil      (cost 25, WIS based)";
    }

    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You feel a holy wrath fill you.";
        HaveMessage = "You can send evil creatures directly to Hell.";
        LoseMessage = "You no longer feel a holy wrath.";
    }
}