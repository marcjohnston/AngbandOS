[Serializable]
internal class PaladinSatisfyHungerLifeSpell : ClassSpell
{
    private PaladinSatisfyHungerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSatisfyHunger);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 10;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 3;
}