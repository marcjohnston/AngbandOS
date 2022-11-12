using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TsathogguaMonsterRace : MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Tsathoggua";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 35, 5),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 35, 5),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 35, 5),
            new MonsterAttack(AttackType.Touch, new AcidAttackEffect(), 35, 5)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheChaos => true;
        public override bool BreatheDisenchant => true;
        public override bool BreatheDisintegration => true;
        public override bool BreatheMana => true;
        public override bool Demon => true;
        public override string Description => "Toad shaped and sleepy, don't let his inoffensive appearance fool you. He still bears all the power of a Great Old One.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool EmptyMind => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Tsathoggua";
        public override bool GreatOldOne => true;
        public override int Hdice => 99;
        public override int Hside => 99;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillItem => true;
        public override bool KillWall => true;
        public override int LevelFound => 93;
        public override bool LightningAura => true;
        public override int Mexp => 50000;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override bool ResistDisenchant => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 100;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Tsathoggua ";
        public override bool Stupid => true;
        public override bool SummonCthuloid => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
