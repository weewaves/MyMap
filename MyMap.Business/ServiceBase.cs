using AutoMapper;
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
    }
}
