using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GripFarmerMaggotsDogMonsterRace : MonsterRace
    {
        public override char Character => 'C';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Grip, Farmer Maggot's dog";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A rather vicious dog belonging to Farmer Maggot. It thinks you are stealing mushrooms.";
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grip, Farmer Maggot's dog";
        public override int Hdice => 5;
        public override int Hside => 5;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 2;
        public override int Mexp => 30;
        public override int NoticeRange => 30;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Grip    ";
        public override bool Unique => true;
    }
}
