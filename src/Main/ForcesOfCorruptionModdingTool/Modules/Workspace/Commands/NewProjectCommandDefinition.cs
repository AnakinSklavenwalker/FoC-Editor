﻿using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.ProjectDefinitions;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.MVVM.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Caliburn.Micro;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    [Export(typeof(NewProjectCommandDefinition))]
    public class NewProjectCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import]
        private IModdingToolWorkspace _workspace;

        [ImportMany]
        private ISupportedProjectDefinition[] _definitions;

#pragma warning restore 649

        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => false;
        public override string IconId => "NewProjectIcon";

        public override Uri IconSource => new Uri("/ForcesOfCorruptionModdingTool;component/Resources/Icons/NewProject.xaml",
                    UriKind.RelativeOrAbsolute);

        public override string Name => "New Project";
        public override string Text => Name;
        public override string ToolTip => "Creates a new Project";

        public override ICommand Command { get; }

        public NewProjectCommandDefinition()
        {
            Command = new GestureCommandWrapper(CreateNewProject, CanCreateNewProject, new KeyGesture(Key.N, ModifierKeys.Control | ModifierKeys.Shift));
        }

        private void CreateNewProject()
        {
            var vm = (INewElementDialogModel)IoC.GetInstance(typeof(INewElementDialogModel), null);

            vm.ItemPresenter = new ProjectItemPresenter { ItemSource = _definitions };
            vm.DisplayName = "New Project";

            if (_workspace.Game.GameDirectory != null)
                vm.Path = Path.Combine(_workspace.Game.GameDirectory, "Mods");

            var windowManager = IoC.Get<IWindowManager>();
            if (windowManager.ShowDialog(vm) != true)
                return;

            var pi = vm.ResultData as ProjectInformation;
            if (pi == null)
                return;

            _workspace.CreateProject(pi);
        }

        private static bool CanCreateNewProject()
        {
            return IoC.GetAll<ISupportedProjectDefinition>().Any();
        }
    }
}