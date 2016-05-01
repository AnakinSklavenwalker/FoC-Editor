﻿using System;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces
{
    public interface IEngineFile : IDisposable
    {
        string FilePath { get; }

        string Name { get; }

        byte[] ByteArray { get; set; }

        void Open();

        void Save();
    }
}
