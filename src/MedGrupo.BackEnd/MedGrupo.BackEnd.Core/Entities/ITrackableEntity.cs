using System;

namespace MedGrupo.BackEnd.Core.Entities
{
    public interface ITrackableEntity<T> where T : EntityBase
    {
        DateTime CreatedAt { get; }
        DateTime LastUpdatedAt { get; }
    }
}
