namespace ShopApp.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entitiy</returns>
        T? Get(string name);
        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity created</returns>
        void Create(T entity);
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        List<T> GetAll();

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="name"></param>
        void Delete(T entity);
    }
}
