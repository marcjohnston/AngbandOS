internal class PaladinDispelCurseLifeSpell : ClassSpell
{
    private PaladinDispelCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelCurse);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 24;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}