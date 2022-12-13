using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class VortTheKoboldQueenMonsterRace : MonsterRace
    {
        public override char Character => 'k';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Vort the Kobold Queen";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
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
}
