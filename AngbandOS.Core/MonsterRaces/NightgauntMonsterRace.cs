using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NightgauntMonsterRace : MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Nightgaunt";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new LoseStrAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Touch, new ParalyzeAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "It is a black, horned humanoid with wings.";
        public override bool Drop60 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Nightgaunt";
        public override int Hdice => 24;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 1000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Nightgaunt ";
    }
}
