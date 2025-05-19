// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HomonculousMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerUSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 32;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 1, 2),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a small demonic spirit full of malevolence.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Homonculous";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override int LevelFound => 15;
    public override int Mexp => 40;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Homonculous";
}
