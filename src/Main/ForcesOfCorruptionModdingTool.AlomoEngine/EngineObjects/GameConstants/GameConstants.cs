﻿using System;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    public sealed class GameConstants : GameXmlFile
    {
        public GameConstants(IGameXmlFile parent) : base(parent) {}

        public GameConstants() : base(null) {}

        public DebugHotKeyLoadData DebugHotKeyLoadData { get; private set; }

        public GameConstantsData GameConstantsData { get; private set; }

        public ObjectMaximumMultipliers ObjectMaximumMultipliers { get; private set; }

        public PlayerFactionData PlayerFactionData { get; private set; }

        public ShipLoadVulnerabilityData ShipLoadVulnerabilityData { get; private set; }

        public GalacticFleetMovementData GalacticFleetMovementData { get; private set; }

        public GameScrollData GameScrollData { get; private set; }

        public override void Deserialize(XmlDocument document)
        {
            base.Deserialize(document);
            DebugHotKeyLoadData = new DebugHotKeyLoadData(this);
            DebugHotKeyLoadData.Deserialize(RootNode);

            GameConstantsData = new GameConstantsData(this);
            GameConstantsData.Deserialize(RootNode);

            ObjectMaximumMultipliers = new ObjectMaximumMultipliers(this);
            ObjectMaximumMultipliers.Deserialize(RootNode);

            PlayerFactionData = new PlayerFactionData(this);
            PlayerFactionData.Deserialize(RootNode);

            ShipLoadVulnerabilityData = new ShipLoadVulnerabilityData(this);
            ShipLoadVulnerabilityData.Deserialize(RootNode);

            GalacticFleetMovementData = new GalacticFleetMovementData(this);
            GalacticFleetMovementData.Deserialize(RootNode);

            GameScrollData = new GameScrollData(this);
            GameScrollData.Deserialize(RootNode);
        }

        public override void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public override XmlElement Serialize()
        {
            RootNode = DebugHotKeyLoadData.Serialize();
            RootNode = GameConstantsData.Serialize();
            RootNode = ObjectMaximumMultipliers.Serialize();
            RootNode = PlayerFactionData.Serialize();
            RootNode = ShipLoadVulnerabilityData.Serialize();
            RootNode = GalacticFleetMovementData.Serialize();
            RootNode = GameScrollData.Serialize();
            return RootNode;
        }
    }
}