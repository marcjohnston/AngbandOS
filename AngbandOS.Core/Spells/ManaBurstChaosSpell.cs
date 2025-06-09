// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ManaBurstChaosSpell : Spell
{
    private ManaBurstChaosSpell(Game game) : base(game) { }
    public override string Name => "Mana Burst";

    protected override string LearnedDetails 
    {
        get
        {
            int i = Game.ExperienceLevel.IntValue + (Game.ExperienceLevel.IntValue / (Game.BaseCharacterClass.ID == CharacterClassEnum.Mage || Game.BaseCharacterClass.ID == CharacterClassEnum.HighMage ? 2 : 4));
            return $"dam 3d5+{i}";
        }
    }
}
