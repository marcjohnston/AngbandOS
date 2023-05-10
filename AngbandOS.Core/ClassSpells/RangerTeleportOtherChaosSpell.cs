internal class RangerTeleportOtherChaosSpell : ClassSpell
{
    private RangerTeleportOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportOther);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 29;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 5;
}