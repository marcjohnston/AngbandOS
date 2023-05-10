internal class MageWonderChaosSpell : ClassSpell
{
    private MageWonderChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWonder);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 10;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 5;
}