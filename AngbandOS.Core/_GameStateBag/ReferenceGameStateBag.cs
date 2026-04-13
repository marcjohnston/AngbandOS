// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;
    internal class ReferenceGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public ReferenceGameStateBag(int objectId)
    {
        ObjectId = objectId;
    }
    public override string ToString()
    {
        return $"=>{ObjectId}";
    }
    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is null || restoreGameState.GetObjectById(ObjectId) != singleton)
        {
            throw new Exception("Reference fails to verify.");
        }
        return true;
    }
}