using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class HellbladeMonsterRace : MonsterRace
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Hellblade";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new Exp20AttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Hit, new Exp20AttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A deadly blade of chaos, moving of its own volition.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hellblade";
        public override int Hdice => 13;
        public override int Hside => 13;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 27;
        public override int Mexp => 130;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Hellblade  ";
    }
}