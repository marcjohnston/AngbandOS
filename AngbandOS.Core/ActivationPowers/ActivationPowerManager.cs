using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AngbandOS.ActivationPowers
{
    internal static class ActivationPowerManager
    {
        public static readonly IActivationPower[] ActivationPowers;

        /// <summary>
        /// Returns a specific artifact power.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IActivationPower FindByType(Type type)
        {
            return ActivationPowers.SingleOrDefault(artifactPower => artifactPower.GetType() == type);
        }

        /// <summary>
        /// Returns a random artifact power.
        /// </summary>
        /// <returns></returns>
        public static IActivationPower GetRandom()
        {
            int index = Program.Rng.DieRoll(ActivationPowers.Length) - 1;
            return ActivationPowers[index];
        }

        static ActivationPowerManager()
        {
            List<IActivationPower> artifactPowerList = new List<IActivationPower>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Check to see if the type implements the IArtifactPower interface and is not an abstract class.
                if (!type.IsAbstract && typeof(IActivationPower).IsAssignableFrom(type))
                {
                    // Load the command.
                    IActivationPower artifactPower = (IActivationPower)Activator.CreateInstance(type);
                    artifactPowerList.Add(artifactPower);
                }
            }

            ActivationPowers = artifactPowerList.ToArray();
        }
    }
}
