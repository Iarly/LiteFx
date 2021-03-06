﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteFx.Specs.RepositorySpecs
{
    public interface IOrdinaryContext : IContext 
    {
        IQueryable<Entity> Entities { get; }
    }

    public class OrdinaryContext : IOrdinaryContext
    {
        public IQueryable<T> GetQueryableObject<T>() where T : class
        {
            if (typeof(T) == typeof(Entity))
                return (IQueryable<T>)Entities;

            return null;
        }

        public void SaveContext()
        {
            throw new NotImplementedException();
        }

        public void Save(object entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entity> Entities
        {
            get 
            {
                IList<Entity> entities = new List<Entity>();
                entities.Add(new Entity() { Id = 1 });
                return entities.AsQueryable();
            }
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }


		public T Delete<T, TId>(TId id) where TId : IEquatable<TId>
		{
			throw new NotImplementedException();
		}
	}
}
