// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TulzschaMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.FireBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBoltMonsterSpell),
        nameof(MonsterSpellsEnum.BlinkMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportSelfMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override int ArmorClass => 170;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 0, 0),
        (nameof(HitAttack), nameof(AttackEffectsEnum.BlindAttackEffect), 10, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 10),
        (nameof(EngulfAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "'A belching column of sick greenish flame... spouting volcanically from depths profound and inconceivable, casting no shadows as a healthy flame should, and coating the nitrous stone with a nasty venomous verdigris.' H.P.Lovecraft - 'The Festival'.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Tulzscha";
    public override bool GreatOldOne => true;
    public override int Hdice => 60;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 57;
    public override int Mexp => 30000;
    public override bool MoveBody => true;
    public override bool NeverMove => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistNether => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Tulzscha";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
