// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class BanishActiveMutation : Mutation
{
    private BanishActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(25, 25, Ability.Wisdom, 18))
        {
            return;
        }
        if (!SaveGame.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[dir];
        int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[dir];
        GridTile cPtr = SaveGame.Grid[y][x];
        if (cPtr.MonsterIndex == 0)
        {
            SaveGame.MsgPrint("You sense no evil there!");
            return;
        }
        Monster mPtr = SaveGame.Monsters[cPtr.MonsterIndex];
        MonsterRace rPtr = mPtr.Race;
        if (rPtr.Evil)
        {
            SaveGame.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
            SaveGame.MsgPrint("The evil creature vanishes in a puff of sulfurous smoke!");
        }
        else
        {
            SaveGame.MsgPrint("Your invocation is ineffectual!");
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 25 ? "banish evil      (unusable until level 25)" : "banish evil      (cost 25, WIS based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "You feel a holy wrath fill you.";
    public override string HaveMessage => "You can send evil creatures directly to Hell.";
    public override string LoseMessage => "You no longer feel a holy wrath.";
}