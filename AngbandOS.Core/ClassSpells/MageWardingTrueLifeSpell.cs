internal class MageWardingTrueLifeSpell : ClassSpell
{
    private MageWardingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellWardingTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 70;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}