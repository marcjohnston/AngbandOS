// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellWonder : Spell
{
    private ChaosSpellWonder(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.RunScript(nameof(SpellOfWonderScript));
    }

    public override void CastFailed()
    {
        SaveGame.RunSpellScript(nameof(WildChaoticMagicScript), this);
    }

    public override string Name => "Wonder";

    protected override string LearnedDetails => "random";
}