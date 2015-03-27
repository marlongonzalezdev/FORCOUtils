using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FORCOUtils
{
    public enum OrderFunctionType
    {
        Descending,
        Ascending
    }

    public interface IGenericRepository<T> where T : class
    {
        #region GetAll EagerLoading methods

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects of specified type from the repository source
        ///  </summary>
        /// <returns>IList of objects with all the objects of the specified type on the repository</returns>
        IList<T> GetAll();

        ///<author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects of specified type from the repository source
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type</returns>
        IList<TU> GetAllWithSelect<TU>(Func<T, TU> aSelectFunc) where TU : class;

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified type from the repository source in a specific order
        ///  </summary>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <returns>IList of objects with all the objects of the specified type on the repository</returns>
        IList<T> GetAll(Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type in a specific order</returns>
        IList<TU> GetAllWithSelect<TU>(Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType) where TU : class;


        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified  type from the repository source in a specific order and using pagination
        /// </summary>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <returns>IList of objects with all the objects of the specified type on the repository</returns>
        IList<T> GetAll(int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order and using pagination
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type in a specific order and using pagination</returns>
        IList<TU> GetAllWithSelect<TU>(int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType);

        #endregion

        #region GetAll LazyLoading methods

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects of specified type from the repository source
        ///  </summary>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with all the objects of the specified type on the repository. Lazy loading used</returns>
        IList<T> GetAllLazyLoading(params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects fomr the source and selects from them some specific fields
        ///  </summary>
        ///  <typeparam name="TU">The type for the selected object to return</typeparam>
        ///  <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type. Lazy loading used</returns>
        IList<TU> GetAllLazyLoadingWithSelect<TU>(Func<T, TU> aSelectFunc, params Expression<Func<T, object>>[] aNavigationProperties) where TU : class;

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified type from the repository source in a specific order
        ///  </summary>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with all the objects of the specified type on the repository. Lazy loading used</returns>
        IList<T> GetAllLazyLoading(Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aOrderFunc"></param>
        /// <param name="aOrderFunctionType"></param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type in a specific order. Lazy loading used</returns>
        IList<TU> GetAllLazyLoadingWithSelect<TU>(Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties) where TU : class;


        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified  type from the repository source in a specific order and using pagination
        /// </summary>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with all the objects of the specified type on the repository. Lazy loading used</returns>
        IList<T> GetAllLazyLoading(int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order and using pagination
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type in a specific order and using pagination</returns>
        IList<TU> GetAllLazyLoadingWithSelect<TU>(int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties);

        #endregion GetAll LazyLoading

        #region GetList EagerLoading methods

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects of specified type from the repository source
        ///  </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression</returns>
        IList<T> GetList(Func<T, bool> aWhere);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects of specified type from the repository source
        ///  </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression</returns>
        IList<TU> GetListWithSelect<TU>(Func<T, bool> aWhere, Func<T, TU> aSelectFunc) where TU : class;

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified type from the repository source in a specific order
        ///  </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression</returns>
        IList<T> GetList(Func<T, bool> aWhere, Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <returns>IList of new objects created from the list of objects in the repository according to boolean expression and converted to the select function out type in a specific order</returns>
        IList<TU> GetListWithSelect<TU>(Func<T, bool> aWhere, Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType) where TU : class;


        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified  type from the repository source in a specific order and using pagination
        /// </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression with specific order and using pagination</returns>
        IList<T> GetList(Func<T, bool> aWhere, int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order and using pagination
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type in a specific order and using pagination</returns>
        IList<TU> GetListWithSelect<TU>(Func<T, bool> aWhere, int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType);



        #endregion

        #region GetList LazyLoading methods

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects of specified type from the repository source
        ///  </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression. Lazy loading used</returns>
        IList<T> GetListLazyLoading(Func<T, bool> aWhere, params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        ///  <summary>
        ///  Fetch objects of specified type from the repository source
        ///  </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression. Lazy loading used</returns>
        IList<TU> GetListWithSelectLazyLoading<TU>(Func<T, bool> aWhere, Func<T, TU> aSelectFunc, params Expression<Func<T, object>>[] aNavigationProperties) where TU : class;

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified type from the repository source in a specific order
        ///  </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression. Lazy loading used</returns>
        IList<T> GetListLazyLoading(Func<T, bool> aWhere, Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of new objects created from the list of objects in the repository according to boolean expression and converted to the select function out type in a specific order. Lazy loading used</returns>
        IList<TU> GetListWithSelectLazyLoading<TU>(Func<T, bool> aWhere, Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties) where TU : class;


        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        ///  Fetch objects of specified  type from the repository source in a specific order and using pagination
        /// </summary>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of objects with objects of the specified type on the repository according to boolean expression with specific order and using pagination. Lazy loading used</returns>
        IList<T> GetListLazyLoading(Func<T, bool> aWhere, int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch objects from the source and selects from them some specific fields in a specific order and using pagination
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aWhere">Boolean expression to filter the list to return</param>
        /// <param name="aPage">Sets the page to load</param>
        /// <param name="aCount">Sets the number of items per page to load</param>
        /// <param name="aPageCount">Returns the number of pages after fetchig the results</param>
        /// <param name="aOrderFunc">Sets the  order by funtion for the collection</param>
        /// <param name="aSelectFunc">A select function to return a new type only with specified fields</param>
        /// <param name="aOrderFunctionType">Sets the ordering type for the collection</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>IList of new objects created from the list of all objects in the repository and converted to the select function out type in a specific order and using pagination. Lazy loading used</returns>
        IList<TU> GetListWithSelectLazyLoading<TU>(Func<T, bool> aWhere, int aPage, int aCount, out int aPageCount, Func<T, object> aOrderFunc, Func<T, TU> aSelectFunc, OrderFunctionType aOrderFunctionType, params Expression<Func<T, object>>[] aNavigationProperties);

        #endregion GetList LazyLoading

        #region GetSingleEagerLoading methods

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch a single object from the source
        /// </summary>
        /// <returns>The frist object in the source or null if none exist</returns>
        T GetSingle();

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch a single object from the source
        /// </summary>
        /// <param name="aWhere">Boolean expression to filter the object to return</param>
        /// <returns>A single object with all associated objects to it</returns>
        T GetSingle(Func<T, bool> aWhere);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch a single object from the source
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aWhere">Boolean expression to filter the object to return</param>
        /// <returns>A single object according to select function out type</returns>
        TU GetSingle<TU>(Func<T, bool> aWhere) where TU : class;

        #endregion

        #region GetSingleLazyLoading methods

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch a single object from the source
        /// </summary>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>A single object with all associated objects to it</returns>
        T GetSingleLazyLoading(params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch a single object from the source
        /// </summary>
        /// <param name="aWhere">Boolean expression to filter the object to return</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>A single object with all associated objects to it. Lazy Loading used</returns>
        T GetSingleLazyLoading(Func<T, bool> aWhere, params Expression<Func<T, object>>[] aNavigationProperties);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Fetch a single object from the source
        /// </summary>
        /// <typeparam name="TU">The type for the selected object to return</typeparam>
        /// <param name="aWhere">Boolean expression to filter the object to return</param>
        /// <param name="aNavigationProperties">The properties to include on the lazy loading</param>
        /// <returns>A single object according to select function out type. Lazy Loading used</returns>
        TU GetSingleLazyLoading<TU>(Func<T, bool> aWhere, params Expression<Func<T, object>>[] aNavigationProperties) where TU : class;
        #endregion

        #region Count, Add, Update and Delete methods


        int Count();

        int Count(Func<T, bool> aWhere);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Adds new items to the source
        /// </summary>
        /// <param name="aItems">The items to add</param>
        void Add(params T[] aItems);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Updates items on the source
        /// </summary>
        /// <param name="aItems">The items to update</param>
        void Update(params T[] aItems);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Removes items from the source
        /// </summary>
        /// <param name="aItems"></param>
        void Remove(params T[] aItems);

        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Removes all items from the source
        /// </summary>
        void RemoveAll();

        #endregion

    }
}
