[Serializable]
internal class PaladinExorcismLifeSpell : ClassSpell
{
    private PaladinExorcismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellExorcism);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 22;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}