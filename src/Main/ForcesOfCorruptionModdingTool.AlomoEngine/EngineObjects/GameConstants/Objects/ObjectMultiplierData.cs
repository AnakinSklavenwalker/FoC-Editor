﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ObjectMultiplierData : EngineObject
    {
        public ObjectMultiplierData(IGameXmlFile parent) : base(parent) {}

        public double Object_Max_Speed_Multiplier_Galactic { get; set; }

        public double Object_Max_Speed_Multiplier_Space { get; set; }

        public double Object_Max_Speed_Multiplier_Land { get; set; }

        public double Object_Max_Health_Multiplier_Space { get; set; }

        public double Object_Max_Health_Multiplier_Land { get; set; }

        [Description("This entry can be used to artificially make build times faster in tactical mode when debugging.")]
        public double Tactical_Build_Time_Multiplier { get; set; }

        public override void Deserialize(XmlElement node)
        {
            Description = node.GetCommentsOverElements(nameof(Object_Max_Speed_Multiplier_Galactic),
                nameof(Object_Max_Health_Multiplier_Land));

            Object_Max_Speed_Multiplier_Galactic =
                node.GetValueOfLastTagOfName(nameof(Object_Max_Speed_Multiplier_Galactic)).ToEngineFloat();

            Object_Max_Speed_Multiplier_Space =
                node.GetValueOfLastTagOfName(nameof(Object_Max_Speed_Multiplier_Space)).ToEngineFloat();

            Object_Max_Speed_Multiplier_Land =
                node.GetValueOfLastTagOfName(nameof(Object_Max_Speed_Multiplier_Land)).ToEngineFloat();

            Object_Max_Health_Multiplier_Space =
                node.GetValueOfLastTagOfName(nameof(Object_Max_Health_Multiplier_Space)).ToEngineFloat();

            Object_Max_Health_Multiplier_Land =
                node.GetValueOfLastTagOfName(nameof(Object_Max_Health_Multiplier_Land)).ToEngineFloat();

            Tactical_Build_Time_Multiplier =
               node.GetValueOfLastTagOfName(nameof(Tactical_Build_Time_Multiplier)).ToEngineFloat();
        }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Object_Max_Speed_Multiplier_Galactic), Object_Max_Speed_Multiplier_Galactic.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Object_Max_Speed_Multiplier_Space), Object_Max_Speed_Multiplier_Space.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Object_Max_Speed_Multiplier_Land), Object_Max_Speed_Multiplier_Land.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Object_Max_Health_Multiplier_Space), Object_Max_Health_Multiplier_Space.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Object_Max_Health_Multiplier_Land), Object_Max_Health_Multiplier_Land.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Tactical_Build_Time_Multiplier), Tactical_Build_Time_Multiplier.ToString(CultureInfo.InvariantCulture));
            return node;
        }
    }
}