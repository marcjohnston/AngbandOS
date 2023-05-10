[Serializable]
internal class MageAlterRealityChaosSpell : ClassSpell
{
    private MageAlterRealityChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellAlterReality);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 150;
}