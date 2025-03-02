// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellHolyOrb : Spell
{
    private LifeSpellHolyOrb(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(HolyOrbScript) };

    public override string Name => "Holy Orb";
    
    protected override string LearnedDetails
    {
        get
        {
            int orb = Game.ExperienceLevel.IntValue / (Game.BaseCharacterClass.ID == CharacterClassEnum.Priest || Game.BaseCharacterClass.ID == CharacterClassEnum.HighMage ? 2 : 4);
            return $" dam 3d6+{Game.ExperienceLevel.IntValue + orb}";
        }
    }
}