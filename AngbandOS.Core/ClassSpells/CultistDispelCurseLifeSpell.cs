[Serializable]
internal class CultistDispelCurseLifeSpell : ClassSpell
{
    private CultistDispelCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelCurse);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}