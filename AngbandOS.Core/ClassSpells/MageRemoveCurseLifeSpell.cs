[Serializable]
internal class MageRemoveCurseLifeSpell : ClassSpell
{
    private MageRemoveCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveCurse);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 4;
}