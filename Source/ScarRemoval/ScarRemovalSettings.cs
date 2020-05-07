using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;
using System.Reflection;

namespace SyrScarRemoval
{
    public class ScarRemovalSettings : ModSettings
    {
        public static bool hardMode;
        public static bool applyToAnimals;
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref hardMode, "ScarRemoval_hardMode", false, true);
            Scribe_Values.Look<bool>(ref applyToAnimals, "ScarRemoval_applyToAnimals", false, true);
        }
    }
}
