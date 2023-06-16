// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellAnnihilation : Spell
{
    private DeathSpellAnnihilation(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Player.Mana -= 100;
        for (int i = 1; i < SaveGame.Level.MMax; i++)
        {
            Monster mPtr = SaveGame.Level.Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (rPtr.Unique)
            {
                continue;
            }
            if (rPtr.Guardian)
            {
                continue;
            }
            SaveGame.Level.DeleteMonsterByIndex(i, true);
            SaveGame.Player.TakeHit(Program.Rng.DieRoll(4), "the strain of casting Annihilation");
            SaveGame.Player.Mana++;
            SaveGame.Level.MoveCursorRelative(SaveGame.Player.MapY, SaveGame.Player.MapX);
            SaveGame.RedrawHpFlaggedAction.Set();
            SaveGame.RedrawManaFlaggedAction.Set();
            SaveGame.HandleStuff();
            SaveGame.UpdateScreen();
            SaveGame.Pause(Constants.DelayFactorInMilliseconds);
        }
        SaveGame.Player.Mana += 100;
    }

    public override string Name => "Annihilation";
    
}