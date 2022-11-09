using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DracolichMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightBeige;
        public override string Name => "Dracolich";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Bite, new Exp80AttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Bite, new Exp80AttackEffect(), 3, 6)
        };
        public override bool BashDoor => true;
        public override bool BreatheCold => true;
        public override bool BreatheNether => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override string Description => "The skeletal form of a once-great dragon, enchanted by magic most perilous. Its animated form strikes with speed and drains life from its prey to satisfy its hunger.";
        public override bool Dragon => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Dracolich";
        public override int Hdice => 35;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 46;
        public override int Mexp => 18000;
        public override bool MoveBody => true;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Dracolich  ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
