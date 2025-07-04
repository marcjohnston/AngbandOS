// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SnagaMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 32;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "He is one of the many weaker 'slave' orcs, often mistakenly known as a goblin.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Snaga";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override int LevelFound => 6;
    public override bool Male => true;
    public override int Mexp => 15;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Snaga";
}
