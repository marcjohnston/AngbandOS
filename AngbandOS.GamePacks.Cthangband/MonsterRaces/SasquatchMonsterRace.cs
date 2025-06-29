// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SasquatchMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperYSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override bool Animal => true;
    public override int ArmorClass => 40;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 10),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 10),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A tall shaggy, furry humanoid, it could call the yeti brother.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Sasquatch";
    public override int Hdice => 20;
    public override int Hside => 19;
    public override bool ImmuneCold => true;
    public override int LevelFound => 20;
    public override int Mexp => 180;
    public override int NoticeRange => 15;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Sasquatch";
}
