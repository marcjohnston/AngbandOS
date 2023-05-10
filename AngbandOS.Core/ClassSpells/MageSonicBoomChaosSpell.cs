internal class MageSonicBoomChaosSpell : ClassSpell
{
    private MageSonicBoomChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSonicBoom);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 13;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 10;
}