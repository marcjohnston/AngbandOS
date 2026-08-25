namespace AngbandOS.Core.Scripts;
internal class SterilityMutationScript : ActiveMutationScript
{
    private SterilityMutationScript(Game game) : base(game) { }
    public override string Name => "sterilize";
    public override void ExecuteScript()
    {
        Game.MsgPrint("You suddenly have a headache!");
        Game.TakeHit(base.Game.DieRoll(30) + 30, "the strain of forcing abstinence");
        Game.NumRepro += Constants.MaxRepro;
    }
}