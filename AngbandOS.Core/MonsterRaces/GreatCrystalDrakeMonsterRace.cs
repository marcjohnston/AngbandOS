using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreatCrystalDrakeMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheShardsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new SlowMonsterSpell());
        public override char Character => 'D';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Great crystal drake";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 9),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 9),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 5, 12),
        };
        public override bool BashDoor => true;
        public override string Description => "A huge crystalline dragon. Its claws could cut you to shreds and its teeth are razor sharp. Strange colours ripple through it as it moves in the light.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Great crystal drake";
        public override int Hdice => 15;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 40;
        public override int Mexp => 3500;
        public override bool MoveBody => true;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Reflecting => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "   Great    ";
        public override string SplitName2 => "  crystal   ";
        public override string SplitName3 => "   drake    ";
    }
}
