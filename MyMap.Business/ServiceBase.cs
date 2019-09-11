using AutoMapper;
using MyMap.Business.Model;
using MyMap.DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMap.Business
{
    public class ServiceBase
    {
        private IMyMapDbContext _dbContext;

        public ServiceBase(IMyMapDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            Mapper = mapper;
        }

        protected IMyMapDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        protected IMapper Mapper { get; }

        protected BusinessResult CreateSuccessResult()
        {
            return BusinessResult.Success();
        }

        protected BusinessResult<T> CreateSuccessResult<T>(T value)
        {
            return BusinessResult<T>.Success(value);
        }

        protected BusinessResult CreateErrorResult(string fieldName, string message)
        {
            return BusinessResult.Error(fieldName, message);
        }

        protected BusinessResult CreateErrorResult<T>(string fieldName, string message)
        {
            return BusinessResult.Error(fieldName, message);
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
