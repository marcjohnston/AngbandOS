[Serializable]
internal class MageNetherBoltDeathSpell : ClassSpell
{
    private MageNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}