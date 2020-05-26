using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiAppWithSwagger.Models;

namespace ApiAppWithSwagger.Data
{
    public class ApiAppWithSwaggerContext : DbContext
    {
        public ApiAppWithSwaggerContext (DbContextOptions<ApiAppWithSwaggerContext> options)
            : base(options)
        {
        }

        public DbSet<ApiAppWithSwagger.Models.TodoItem> TodoItem { get; set; }
    }
}
