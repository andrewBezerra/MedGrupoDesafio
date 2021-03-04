using System;

namespace MedGrupo.BackEnd.Core.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
        
    }
}
