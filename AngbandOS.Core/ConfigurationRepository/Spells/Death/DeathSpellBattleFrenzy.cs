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
        SaveGame.RunScript(nameof(BattleFrenzyScript));
    }

    public override void CastFailed()
    {
        SaveGame.RunScriptIntInt(nameof(WildDeathMagicScript), 19, 2);
    }

    public override string Name => "Battle Frenzy";

    protected override string LearnedDetails => "max dur 50";
}