using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DarkElvenLordMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "Dark elven lord";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A dark elven figure in armour and radiating evil power.";
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Dark elven lord";
        public override bool Haste => true;
        public override int Hdice => 18;
        public override int Hside => 15;
        public override bool HurtByLight => true;
        public override int LevelFound => 20;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "    lord    ";
    }
}
