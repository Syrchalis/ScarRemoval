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
    [DefOf]
    public static class ScarRemovalDefOf
    {
        static ScarRemovalDefOf()
        {

        }
        public static RecipeDef RemoveScar;
        public static RecipeDef RemoveScarBrain;
        public static RecipeDef HealDementia;
        public static RecipeDef HealAlzheimers;
        public static RecipeDef HealFrailty;
    }
}
