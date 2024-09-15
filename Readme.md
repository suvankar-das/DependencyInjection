- First I have created a folder named LifeTimeExercise and there I have created 3 class named SingleTonService,Scoped Service
 and Transient Service. Only class names are different but they will do exactly same thing.

 ```
 public class TransientService
    {
        private readonly Guid _guid;

        public TransientService()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid() => _guid.ToString();
    }
 ```