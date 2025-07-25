// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NexusHoundMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.NexusBreatheBallMonsterSpell)
    };

    public override string SymbolName => nameof(UpperZSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 3),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "A locus of conflicting points coalesce to form the vague shape of a huge hound. Or is it just your imagination?";
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Nexus hound";
    public override bool Friends => true;
    public override int Hdice => 25;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 27;
    public override int Mexp => 250;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override bool ResistNexus => true;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string? MultilineName => "Nexus\nhound";
}
