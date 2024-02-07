// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellBerserk : Spell
{
    private DeathSpellBerserk(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedSuperheroism.AddTimer(SaveGame.Rng.DieRoll(25) + 25);
        SaveGame.RestoreHealth(30);
        SaveGame.TimedFear.ResetTimer();
    }

    public override void CastFailed()
    {
        SaveGame.RunScriptIntInt(nameof(WildDeathMagicScript), 16, 2);
    }

    public override string Name => "Berserk";

    protected override string LearnedDetails => "dur 25+d25";
}