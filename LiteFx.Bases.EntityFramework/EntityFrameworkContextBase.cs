﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;

namespace LiteFx.Bases.EntityFramework
{
    /// <summary>
    /// Entity Framework Context Base.
    /// </summary>
    /// <typeparam name="TId">Type of Entity identificador.</typeparam>
    public class EntityFrameworkContextBase<TId> : ObjectContext, IContext<TId>, IDisposable
        where TId : IEquatable<TId>
    {
        public EntityFrameworkContextBase(string connectionString) : base(connectionString) { }

        #region IDBContext Members

        /// <summary>
        /// Flag usado para identificar se há uma transação aberta.
        /// </summary>
        protected bool openTransaction = false;

        /// <summary>
        /// Variavel que mantem a transação.
        /// </summary>
        protected IDbTransaction transaction;

        /// <summary>
        /// Inicia uma transação e retorna a referência da transação como um IDisposable.
        /// </summary>
        /// <returns>Referência da transação como um IDisposable.</returns>
        public virtual IDisposable BeginTransaction()
        {
            if (openTransaction)
                return transaction;

            transaction = base.Connection.BeginTransaction();
            openTransaction = true;
            return transaction;
        }

        /// <summary>
        /// Salva as alterações realizadas sobre a transação aberta no banco de dados.
        /// </summary>
        public virtual void CommitTransaction()
        {
            if (!openTransaction)
                throw new Exception("Este método pode ser chamado somente após a chamada do método BeginTransaction.");

            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                transaction.Dispose();
                transaction = null;
                openTransaction = false;
            }
        }

        /// <summary>
        /// Descarta as alterações realizadas sobre a transação aberta.
        /// </summary>
        public virtual void RollBackTransaction()
        {
            if (!openTransaction)
                throw new Exception("Este método pode ser chamado somente após a chamada do método BeginTransaction.");

            transaction.Rollback();
            transaction.Dispose();
            openTransaction = false;
        }

        /// <summary>
        /// Get a queryable object of an especifique entity.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <returns>Queryable object.</returns>
        public virtual IQueryable<T> GetQueryableObject<T>() where T : EntityBase<TId>
        {
            return base.CreateObjectSet<T>();
        }

        /// <summary>
        /// Exclui uma entidade do contexto pelo seu Identificador.
        /// </summary>
        /// <typeparam name="T">Tipo do entidade.</typeparam>
        /// <param name="id">Identificador do entidade.</param>
        public virtual T Delete<T>(TId id) where T : EntityBase<TId>, new()
        {
            T entity = new T();
            entity.Id = id;
            entity = (T)base.GetObjectByKey(base.CreateEntityKey(typeof(T).Name, entity));
            Delete(entity);
            return entity;
        }

        /// <summary>
        /// Exclui uma entidade do contexto.
        /// </summary>
        /// <param name="entity">Entidade que será exlcuida.</param>
        public virtual void Delete(object entity)
        {
            BeginTransaction();
            base.DeleteObject(entity);
        }

        /// <summary>
        /// Salva uma entidade no contexto.
        /// </summary>
        /// <param name="entity">Entidade que será salva.</param>
        public virtual void Save(object entity)
        {
            BeginTransaction();
            //if (entity is EntityBase<TId>)
            //{
            //    EntityBase<TId> ent = (EntityBase<TId>)entity;

            //    if(ent.Id.Equals(default(TId)))
            base.AddObject(entity.GetType().Name, entity);
            //    else
            //        base.Attach(
            //}
        }

        /// <summary>
        /// Remove o objeto do cache do contexto.
        /// </summary>
        /// <param name="entity">Objeto a ser removido do cache.</param>
        public virtual void RemoveFromCache(object entity)
        {
            base.Detach(entity);
        }

        /// <summary>
        /// Salva as informações alteradas no contexto no banco de dados.
        /// </summary>
        public virtual void SaveContext()
        {
            try
            {
                CommitTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}