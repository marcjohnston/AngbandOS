[Serializable]
internal class MageDispelCurseLifeSpell : ClassSpell
{
    private MageDispelCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelCurse);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}