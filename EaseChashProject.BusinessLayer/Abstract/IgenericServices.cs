using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaseChashProject.BusinessLayer.Abstract
{
    public interface IgenericServices<T> where T : class
    {
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        T TGetByID(int id);
        List<T> TGetList();
    }
}
