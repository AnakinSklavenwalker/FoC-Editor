﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml;
using AlomoEngine.Xml.Layout;
using ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BountyAwardData : AbstractXmlTagCategory
    {
        public BountyAwardData(IAlomoXmlFile file) : base(file) {}

        public List<BountyCategoryAwardAssociation> Default_Bounty_By_Category_SP { get; set; }
        public List<BountyCategoryAwardAssociation> Default_Bounty_By_Category_MP { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.AddMultipleTagsFromValueList(nameof(Default_Bounty_By_Category_SP),
                Default_Bounty_By_Category_SP.Select(data => data.ToString()).ToList());
            node.AddMultipleTagsFromValueList(nameof(Default_Bounty_By_Category_MP),
                Default_Bounty_By_Category_MP.Select(data => data.ToString()).ToList());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Default_Bounty_By_Category_SP =
               node.GetValuesByNameFromMultipleTags(nameof(Default_Bounty_By_Category_SP))
                   .Select(BountyCategoryAwardAssociation.CreateFromString)
                   .ToList();
            Default_Bounty_By_Category_MP =
               node.GetValuesByNameFromMultipleTags(nameof(Default_Bounty_By_Category_MP))
                   .Select(BountyCategoryAwardAssociation.CreateFromString)
                   .ToList();
        }
    }
}
