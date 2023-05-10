internal class WarriorMageBanishTarotSpell : ClassSpell
{
    private WarriorMageBanishTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellBanish);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 46;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}