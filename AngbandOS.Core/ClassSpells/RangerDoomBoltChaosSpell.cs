internal class RangerDoomBoltChaosSpell : ClassSpell
{
    private RangerDoomBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDoomBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 31;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 10;
}