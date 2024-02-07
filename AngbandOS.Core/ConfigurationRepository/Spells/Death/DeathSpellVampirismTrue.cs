// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellVampirismTrue : Spell
{
    private DeathSpellVampirismTrue(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        for (int dummy = 0; dummy < 3; dummy++)
        {
            if (SaveGame.DrainLife(dir, 100))
            {
                SaveGame.RestoreHealth(100);
            }
        }
    }

    public override void CastFailed()
    {
        SaveGame.RunScriptIntInt(nameof(WildDeathMagicScript), 20, 2);
    }

    public override string Name => "Vampirism True";

    protected override string LearnedDetails => "dam 3*100";
}