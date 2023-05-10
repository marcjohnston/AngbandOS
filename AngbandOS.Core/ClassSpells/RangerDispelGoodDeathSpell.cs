[Serializable]
internal class RangerDispelGoodDeathSpell : ClassSpell
{
    private RangerDispelGoodDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDispelGood);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 40;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}