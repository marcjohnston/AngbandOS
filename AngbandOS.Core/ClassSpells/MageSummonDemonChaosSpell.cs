[Serializable]
internal class MageSummonDemonChaosSpell : ClassSpell
{
    private MageSummonDemonChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSummonDemon);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}