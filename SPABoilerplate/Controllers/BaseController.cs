using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SPABoilerplate.DAL.Common;
using SPABoilerplate.DAL.Contracts;
using SPABoilerplate.Helpers;

namespace SPABoilerplate.Controllers
{
    public class BaseController<TEntity> : ApiController where TEntity : class
    {
        protected IDataAccessObject<TEntity> _dao;
        protected IDataStore _dataStore;

        public BaseController(IDataStore dataStore)
        {
            _dataStore = dataStore;
            _dao = dataStore.GetDataAccessObject<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dao.GetAll();
        }

        public virtual TEntity Get(int id)
        {
            var entity = _dao.Find(id);
            if (entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return entity;
        }

        public virtual HttpResponseMessage Put(TEntity entity)
        {
            if (ModelState.IsValid && entity != null)
            {
                try
                {
                    _dao.Put(entity);
                }
                catch (DataAccessException ex)
                {
                    return ErrorResponse.Create(ex.Error);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public virtual HttpResponseMessage Post(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dao.Add(entity);
                }
                catch (DataAccessException ex)
                {
                    return ErrorResponse.Create(ex.Error);
                }

                return Request.CreateResponse(HttpStatusCode.Created, entity);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public virtual HttpResponseMessage Delete(int id)
        {
            var entity = _dao.Find(id);
            if (entity == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            _dao.Remove(entity);

            try
            {
                _dataStore.SaveChanges();
            }
            catch (DataAccessException ex)
            {
                return ErrorResponse.Create(ex.Error);
            }

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        protected override void Dispose(bool disposing)
        {
            _dao.Dispose();
            base.Dispose(disposing);
        }
    }
}