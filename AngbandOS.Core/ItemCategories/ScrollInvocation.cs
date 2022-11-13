using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollInvocation : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Invocation";

        public override int[] Chance => new int[] { 1, 2, 2, 0 };
        public override int Cost => 200;
        public override string FriendlyName => "Invocation";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 20, 40, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            var patron = eventArgs.SaveGame.PatronList[Program.Rng.DieRoll(eventArgs.SaveGame.PatronList.Length) - 1];
            eventArgs.SaveGame.MsgPrint($"You invoke the secret name of {patron.LongName}.");
            patron.GetReward(eventArgs.SaveGame);
            eventArgs.Identified = true;
        }
    }
}
