internal class MonkPolymorphOtherChaosSpell : ClassSpell
{
    private MonkPolymorphOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphOther);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}