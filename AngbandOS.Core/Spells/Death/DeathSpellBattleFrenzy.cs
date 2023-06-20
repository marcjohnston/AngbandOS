// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellBattleFrenzy : Spell
{
    private DeathSpellBattleFrenzy(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Player.TimedSuperheroism.AddTimer(Program.Rng.DieRoll(25) + 25);
        SaveGame.Player.RestoreHealth(30);
        SaveGame.Player.TimedFear.ResetTimer();
        if (SaveGame.Player.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(20 + (SaveGame.Player.Level / 2)) + (SaveGame.Player.Level / 2));
        }
        else
        {
            SaveGame.Player.TimedHaste.AddTimer(Program.Rng.DieRoll(5));
        }
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(19, 2);
    }

    public override string Name => "Battle Frenzy";
    
    protected override string? Info()
    {
        return "max dur 50";
    }
}