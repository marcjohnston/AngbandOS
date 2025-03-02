// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellOrbOfEntropy : Spell
{
    private DeathSpellOrbOfEntropy(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(OrbOfEntropyScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildDeathMagicScript) };

    public override string Name => "Orb of Entropy";

    protected override string LearnedDetails
    {
        get
        {
            int s = Game.ExperienceLevel.IntValue + (Game.ExperienceLevel.IntValue / (Game.BaseCharacterClass.ID == CharacterClassEnum.Mage || Game.BaseCharacterClass.ID == CharacterClassEnum.HighMage ? 2 : 4));
            return $"dam 3d6+{s}";
        }
    }
}