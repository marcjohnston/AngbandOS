internal class MageTeleportSelfChaosSpell : ClassSpell
{
    private MageTeleportSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportSelf);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 9;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}