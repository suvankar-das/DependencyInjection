using System;

namespace DependencyInjection.Service.LifeTimeExercise
{
    public class SingletonService
    {
        private readonly Guid _guid;

        public SingletonService()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid() => _guid.ToString();
    }
}
