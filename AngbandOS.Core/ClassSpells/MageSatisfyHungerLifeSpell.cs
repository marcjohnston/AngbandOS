[Serializable]
internal class MageSatisfyHungerLifeSpell : ClassSpell
{
    private MageSatisfyHungerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSatisfyHunger);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 14;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 3;
}