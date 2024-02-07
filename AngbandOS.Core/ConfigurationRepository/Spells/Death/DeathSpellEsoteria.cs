// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellEsoteria : Spell
{
    private DeathSpellEsoteria(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (SaveGame.Rng.DieRoll(50) > SaveGame.ExperienceLevel)
        {
            SaveGame.IdentifyItem();
        }
        else
        {
            SaveGame.RunScript(nameof(IdentifyFullyScript));
        }
    }

    public override void CastFailed()
    {
        SaveGame.RunScriptIntInt(nameof(WildDeathMagicScript), 26, 3);
    }

    public override string Name => "Esoteria";
    
}