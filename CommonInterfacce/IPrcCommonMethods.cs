using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
     public interface IPrcCommonMethods<T,I, D,G, S> 
    {

        I InsertUpdate(T objEnitty);
        D Delete(T objEnitty);
        G GetAll();
        S SelectOne(T objEnitty);


    }
}
