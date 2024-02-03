using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;
using MappingSolutionFinal.Models;

namespace MappingSolutionFinal.Models
{


    public partial class DB_APICONTEXT : DbContext

    {

        public DB_APICONTEXT()
        {
        }

        public DB_APICONTEXT(DbContextOptions<DB_APICONTEXT> options) : base(options)
        {
        }

        public DbSet<MappingSolutionFinal.Models.Output> Output { get; set; }

        public DbSet<MappingSolutionFinal.Models.Getuser> Getuser { get; set; }
        //DBCONTEXTOPTION is class related to ENtity framework 
        //DB_APICONTEXT IS OBJECT OF CLASS PASED INSIDE
    }

}