// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VortTheKoboldQueenMonsterRace : MonsterRace
{
    protected VortTheKoboldQueenMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerKSymbol>();
    public override ColourEnum Colour => ColourEnum.Blue;
    public override string Name => "Vort the Kobold Queen";

    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "Strong and powerful, for a kobold.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Vort the Kobold Queen";
    public override int Hdice => 15;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 7;
    public override int Mexp => 100;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "  Vort the  ";
    public override string SplitName2 => "   Kobold   ";
    public override string SplitName3 => "   Queen    ";
    public override bool Unique => true;
}