using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MimeTheNibelungMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Mime, the Nibelung";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Touch, new UnBonusAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override string Description => "This tiny night dwarf is as greedy for gold as his brother, Alberich.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Mime, the Nibelung";
        public override bool Haste => true;
        public override int Hdice => 82;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 24;
        public override bool Male => true;
        public override int Mexp => 300;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Mime    ";
        public override bool Unique => true;
    }
}
