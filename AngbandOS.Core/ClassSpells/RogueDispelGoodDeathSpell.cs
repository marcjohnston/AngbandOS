[Serializable]
internal class RogueDispelGoodDeathSpell : ClassSpell
{
    private RogueDispelGoodDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDispelGood);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 45;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 10;
}