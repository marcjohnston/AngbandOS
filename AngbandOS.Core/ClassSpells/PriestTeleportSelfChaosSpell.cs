internal class PriestTeleportSelfChaosSpell : ClassSpell
{
    private PriestTeleportSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportSelf);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 11;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}