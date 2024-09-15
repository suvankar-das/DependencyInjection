﻿using System;

namespace DependencyInjection.Service.LifeTimeExercise
{
    public class ScopedService
    {
        private readonly Guid _guid;

        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid() => _guid.ToString();
    }
}
