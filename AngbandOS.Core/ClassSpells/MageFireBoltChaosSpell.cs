internal class MageFireBoltChaosSpell : ClassSpell
{
    private MageFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 9;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}