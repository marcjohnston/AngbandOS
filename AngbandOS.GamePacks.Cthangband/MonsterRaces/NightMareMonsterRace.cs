// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NightMareMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerQSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 85;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 2, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A fearsome skeletal horse with glowing eyes, that watch you with little more than a hatred of all that lives.";
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Night mare";
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 39;
    public override int Mexp => 2900;
    public override int NoticeRange => 30;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Night\nmare";
    public override bool Undead => true;
}
