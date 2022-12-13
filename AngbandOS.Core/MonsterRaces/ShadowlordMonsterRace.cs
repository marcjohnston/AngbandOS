using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShadowlordMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ShriekMonsterSpell(),
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell(),
            new NetherBallMonsterSpell(),
            new ScareMonsterSpell(),
            new DarknessMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'G';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Shadowlord";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new Exp40AttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new Exp40AttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Gaze, new TerrifyAttackEffect(), 4, 6)
        };
        public override bool ColdBlood => true;
        public override string Description => "An aura of hatred, cowardice and falsehood surrounds you as this cloaked figure floats towards you.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Shadowlord";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 62;
        public override int Mexp => 22500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Shadowlord ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
