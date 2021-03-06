﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.InspectorTool;
using ModernApplicationFramework.MVVM.Modules.OutputTool;

namespace ModernApplicationFramework_MVVM_ComponentDemo
{
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        private readonly IOutput _output;
        private readonly IInspectorTool _inspectorTool;

        public override IEnumerable<Type> DefaultTools
        {
            get { yield return typeof(IInspectorTool); }
        }

        [ImportingConstructor]
        public Module(IOutput output, IInspectorTool inspectorTool)
        {
            _output = output;
            _inspectorTool = inspectorTool;

        }

        public override void Initialize()
        {
            MainWindow.StatusBar.ModeText = "Test";
            DockingHostViewModel.ShowFloatingWindowsInTaskbar = true;

            _output.AppendLine("Started up");

            DockingHostViewModel.ActiveDocumentChanged += (sender, e) => RefreshInspector();
            RefreshInspector();
            DockingHostViewModel.ShowTool<IInspectorTool>();
            DockingHostViewModel.ShowTool<IOutput>();
        }

        private void RefreshInspector()
        {
            if (DockingHostViewModel.ActiveItem != null)
                _inspectorTool.SelectedObject = new InspectableObjectBuilder()
                    .WithObjectProperties(DockingHostViewModel.ActiveItem, pd => pd.ComponentType == DockingHostViewModel.ActiveItem.GetType())
                    .ToInspectableObject();
            else
                _inspectorTool.SelectedObject = null;

        }
    }
}
