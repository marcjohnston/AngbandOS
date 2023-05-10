[Serializable]
internal class PaladinElderSignLifeSpell : ClassSpell
{
    private PaladinElderSignLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellElderSign);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 70;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 5;
}