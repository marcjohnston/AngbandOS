// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosHoundMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ChaosBreatheBallMonsterSpell)
    };

    public override string SymbolName => nameof(UpperZSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override bool Animal => true;
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 3)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A constantly changing canine form, this hound rushes towards you as if expecting mayhem and chaos ahead. It appears to have an almost kamikaze relish for combat. You suspect all may not be as it seems.";
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Chaos hound";
    public override bool Friends => true;
    public override int Hdice => 60;
    public override int Hside => 30;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 65;
    public override int Mexp => 10000;
    public override int NoticeRange => 30;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Chaos\nhound";
}
