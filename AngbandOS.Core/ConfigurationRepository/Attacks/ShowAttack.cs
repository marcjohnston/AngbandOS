// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackTypes;

[Serializable]
internal class ShowAttack : Attack
{
    private ShowAttack(SaveGame saveGame) : base(saveGame) { }
    public override string MonsterAction(Monster monster) => $"sings to {monster.Name}";
    public override string PlayerAction => SaveGame.SingletonRepository.SingingPlayerAttacks.ToWeightedRandom().ChooseOrDefault();
    public override string KnowledgeAction => "sing";
    public override bool AttackTouchesTarget => false;
    public override bool AttackAwakensTarget => true;
}
