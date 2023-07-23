// AngbandOS: 2022 Marc Johnston
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
        SaveGame.Mana -= 100;
        for (int i = 1; i < SaveGame.MMax; i++)
        {
            Monster mPtr = SaveGame.Monsters[i];
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
            SaveGame.DeleteMonsterByIndex(i, true);
            SaveGame.TakeHit(Program.Rng.DieRoll(4), "the strain of casting Annihilation");
            SaveGame.Mana++;
            SaveGame.MoveCursorRelative(SaveGame.MapY, SaveGame.MapX);
            SaveGame.RedrawHpFlaggedAction.Set();
            SaveGame.RedrawManaFlaggedAction.Set();
            SaveGame.HandleStuff();
            SaveGame.UpdateScreen();
            SaveGame.Pause(Constants.DelayFactorInMilliseconds);
        }
        SaveGame.Mana += 100;
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(30, 3);
    }

    public override string Name => "Annihilation";
    
}