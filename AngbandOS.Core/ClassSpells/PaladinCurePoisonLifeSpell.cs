[Serializable]
internal class PaladinCurePoisonLifeSpell : ClassSpell
{
    private PaladinCurePoisonLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCurePoison);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}