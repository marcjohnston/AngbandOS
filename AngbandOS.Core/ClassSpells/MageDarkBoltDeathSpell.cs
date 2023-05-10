[Serializable]
internal class MageDarkBoltDeathSpell : ClassSpell
{
    private MageDarkBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarkBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 15;
}