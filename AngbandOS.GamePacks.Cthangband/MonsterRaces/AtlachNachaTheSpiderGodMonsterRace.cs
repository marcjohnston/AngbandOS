// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AtlachNachaTheSpiderGodMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DarkBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DarkBallMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessMonsterSpell),
        nameof(MonsterSpellsEnum.CthuloidSummonMonsterSpell),
        nameof(MonsterSpellsEnum.SpiderSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override bool Animal => true;
    public override int ArmorClass => 160;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 9),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 3, 9),
        (nameof(StingAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 2, 5),
        (nameof(StingAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 2, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "'...there was a kind of face on the squat ebon body, low down amid the several-jointed legs. The face peered up with a weird expression of doubt and inquiry...'";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Atlach-Nacha, the Spider God";
    public override bool GreatOldOne => true;
    public override int Hdice => 130;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 75;
    public override int Mexp => 35000;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 8;
    public override bool OnlyDropItem => true;
    public override int Rarity => 1;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Atlach-Nacha";
    public override bool Unique => true;
}
