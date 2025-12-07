using System.Collections.Generic;

namespace Domain.Container
{
    public interface IContainer<in TBase>
    {
        public void Add<T>(T instance) where T : TBase;
        public T Get<T>() where T : TBase;
        
        
    }
}