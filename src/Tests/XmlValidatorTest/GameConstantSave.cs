﻿using ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidatorTest
{
    [TestClass]
    public class GameConstantSave
    {

        private GameConstants Gc { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var parser = new XmlToObjectParser<GameConstants>(@"C:\Test\Gameconstants.xml");
            Gc = parser.Parse();
            Gc.GameConstantsData.Strategic_Queue_Tactical_Battles = false;
            //Gc.DebugHotKeyLoadData.Debug_Hot_Key_Load_Map.Add("teststring");
            //Gc.DebugHotKeyLoadData.Debug_Hot_Key_Load_Map.RemoveAt(0);
            Gc.ObjectMaximumMultipliers.Object_Max_Health_Multiplier_Land = 0;
            Gc.PlayerFactionData.Enemy_Color.Blue = 255;
        }

        [TestMethod]
        public void WriteGameConstants()
        {
            var writer = new ObjectToXmlParser(Gc);
            writer.WriteToXml(@"C:\Test\Gameconstants1.xml");
        }
    }
}