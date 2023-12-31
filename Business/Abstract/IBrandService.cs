﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();

        List<Brand> GetById(int Id);

        List<Brand> Add(Brand brand);
        List<Brand> Update(Brand brand);    
        List<Brand> Delete(Brand brand); 
    }
}
