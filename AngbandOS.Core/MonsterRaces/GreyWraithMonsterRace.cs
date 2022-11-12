using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreyWraithMonsterRace : MonsterRace
    {
        public override char Character => 'W';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Grey wraith";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Touch, new Exp40AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override string Description => "A tangible but ghostly form, made of grey fog. The air around it feels deathly cold.";
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Grey wraith";
        public override int Hdice => 19;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 36;
        public override int Mexp => 700;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Grey    ";
        public override string SplitName3 => "   wraith   ";
        public override bool Undead => true;
    }
}
