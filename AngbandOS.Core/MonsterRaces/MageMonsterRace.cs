using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MageMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Red;
        public override string Name => "Mage";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 5),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override string Description => "A fat mage with glasses.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Mage";
        public override bool Haste => true;
        public override int Hdice => 15;
        public override int Hside => 8;
        public override int LevelFound => 28;
        public override bool LightningBolt => true;
        public override bool Male => true;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Mage    ";
        public override bool SummonMonster => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
    }
}
