﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AiData : EngineObject
    {
        public AiData(IGameXmlFile parent) : base(parent) {}

        public int AI_SpaceEvaluatorRegionSize { get; set; }

        public int AI_LandEvaluatorRegionSize { get; set; }

        public double AI_SpaceThreatDistanceFactor { get; set; }

        public double AI_LandThreatDistanceFactor { get; set; }

        public double AI_SpaceThreatTurnRateFactor { get; set; }

        public double AI_LandThreatTurnRateFactor { get; set; }

        public double AI_SpaceAreaThreatScaleFactor { get; set; }

        public double AI_LandAreaThreatScaleFactor { get; set; }

        public double AI_SpaceThreatLookAheadTime { get; set; }

        public double AI_LandThreatLookAheadTime { get; set; }

        public int AI_FogCellsPerThreatCell { get; set; }

        [Description("Every tick (currently 5 seconds), subtract this % of shields + health from threat tracking on each unit. Note that this serves for Land threat decay as well.")]
        public double AI_SpaceThreatDecayStep { get; set; }

        public int AI_BuildTaskReservationSeconds { get; set; }


        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(AI_SpaceEvaluatorRegionSize), AI_SpaceEvaluatorRegionSize.ToString());
            node.SetValueOfLastTagOfName(nameof(AI_LandEvaluatorRegionSize), AI_LandEvaluatorRegionSize.ToString());
            node.SetValueOfLastTagOfName(nameof(AI_SpaceThreatDistanceFactor), AI_SpaceThreatDistanceFactor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_LandThreatDistanceFactor), AI_LandThreatDistanceFactor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_SpaceThreatTurnRateFactor), AI_SpaceThreatTurnRateFactor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_LandThreatTurnRateFactor), AI_LandThreatTurnRateFactor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_SpaceAreaThreatScaleFactor), AI_SpaceAreaThreatScaleFactor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_LandAreaThreatScaleFactor), AI_LandAreaThreatScaleFactor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_SpaceThreatLookAheadTime), AI_SpaceThreatLookAheadTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_LandThreatLookAheadTime), AI_LandThreatLookAheadTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_FogCellsPerThreatCell), AI_FogCellsPerThreatCell.ToString());
            node.SetValueOfLastTagOfName(nameof(AI_SpaceThreatDecayStep), AI_SpaceThreatDecayStep.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AI_BuildTaskReservationSeconds), AI_BuildTaskReservationSeconds.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            AI_SpaceEvaluatorRegionSize = node.GetValueOfLastTagOfName(nameof(AI_SpaceEvaluatorRegionSize)).ToInteger();
            AI_LandEvaluatorRegionSize = node.GetValueOfLastTagOfName(nameof(AI_LandEvaluatorRegionSize)).ToInteger();
            AI_SpaceThreatDistanceFactor = node.GetValueOfLastTagOfName(nameof(AI_SpaceThreatDistanceFactor)).ToEngineFloat();
            AI_LandThreatDistanceFactor = node.GetValueOfLastTagOfName(nameof(AI_LandThreatDistanceFactor)).ToEngineFloat();
            AI_SpaceThreatTurnRateFactor = node.GetValueOfLastTagOfName(nameof(AI_SpaceThreatTurnRateFactor)).ToEngineFloat();
            AI_LandThreatTurnRateFactor = node.GetValueOfLastTagOfName(nameof(AI_LandThreatTurnRateFactor)).ToEngineFloat();
            AI_SpaceAreaThreatScaleFactor = node.GetValueOfLastTagOfName(nameof(AI_SpaceAreaThreatScaleFactor)).ToEngineFloat();
            AI_LandAreaThreatScaleFactor = node.GetValueOfLastTagOfName(nameof(AI_LandAreaThreatScaleFactor)).ToEngineFloat();
            AI_SpaceThreatLookAheadTime = node.GetValueOfLastTagOfName(nameof(AI_SpaceThreatLookAheadTime)).ToEngineFloat();
            AI_LandThreatLookAheadTime = node.GetValueOfLastTagOfName(nameof(AI_LandThreatLookAheadTime)).ToEngineFloat();
            AI_FogCellsPerThreatCell = node.GetValueOfLastTagOfName(nameof(AI_FogCellsPerThreatCell)).ToInteger();
            AI_SpaceThreatDecayStep = node.GetValueOfLastTagOfName(nameof(AI_SpaceThreatDecayStep)).ToEngineFloat();
            AI_BuildTaskReservationSeconds = node.GetValueOfLastTagOfName(nameof(AI_BuildTaskReservationSeconds)).ToInteger();
        }
    }
}