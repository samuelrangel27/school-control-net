using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using school_control_net.DbContexts;

namespace school_control_net.OData
{
    public class ODataBaseController<TEntity> : ODataController
        where TEntity : class
    {
        private readonly SchoolDbContext _dbContext;
        private readonly ILogger<ODataBaseController<TEntity>> _logger;

        public ODataBaseController(SchoolDbContext dbContext, ILogger<ODataBaseController<TEntity>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 3)]
        public virtual IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }
    }
}