[Serializable]
internal class PaladinDispelGoodDeathSpell : ClassSpell
{
    private PaladinDispelGoodDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDispelGood);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 16;
}