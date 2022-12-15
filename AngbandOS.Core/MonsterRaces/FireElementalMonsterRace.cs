using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FireElementalMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new FireBoltMonsterSpell());
        public override char Character => 'E';
        public override Colour Colour => Colour.Red;
        public override string Name => "Fire elemental";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 4, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a towering inferno of flames.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Fire elemental";
        public override int Hdice => 30;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int LevelFound => 33;
        public override int Mexp => 350;
        public override int NoticeRange => 12;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => " elemental  ";
    }
}
