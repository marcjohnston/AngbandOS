[Serializable]
internal class PaladinRemoveFearLifeSpell : ClassSpell
{
    private PaladinRemoveFearLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveFear);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}