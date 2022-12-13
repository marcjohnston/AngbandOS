using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ElderThingMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new RadiationBallMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new PoisonBallMonsterSpell(),
            new ScareMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportAwayMonsterSpell());
        public override char Character => 'A';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Elder thing";

        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Touch, new LoseWisAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override bool Demon => true;
        public override string Description => "It is barrel-shaped, with horizontal arms and a starfish head.";
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Elder thing";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 36;
        public override int Mexp => 800;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Elder    ";
        public override string SplitName3 => "   thing    ";
    }
}
