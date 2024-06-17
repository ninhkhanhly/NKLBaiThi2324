using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NKLBaiThi2324.Models;

    public class LTQDD : DbContext
    {
        public LTQDD (DbContextOptions<LTQDD> options)
            : base(options)
        {
        }

        public DbSet<NKLBaiThi2324.Models.NKL425Student> NKL425Student { get; set; } = default!;

public DbSet<NKLBaiThi2324.Models.NKL425Employee> NKL425Employee { get; set; } = default!;
    }
