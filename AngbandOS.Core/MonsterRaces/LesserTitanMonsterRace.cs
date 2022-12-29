using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LesserTitanMonsterRace : MonsterRace
    {
        protected LesserTitanMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ScareMonsterSpell(),
            new HealMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'P';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Lesser titan";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 6, 6),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 6, 6),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 6, 6),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 6, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "It is a humanoid figure thirty feet tall that gives off an aura of power and hate.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Lesser titan";
        public override bool Giant => true;
        public override int Hdice => 10;
        public override int Hside => 100;
        public override int LevelFound => 40;
        public override bool Male => true;
        public override int Mexp => 3500;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 15;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Lesser   ";
        public override string SplitName3 => "   titan    ";
        public override bool TakeItem => true;
    }
}
