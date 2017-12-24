using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvcServer.Utility
{
    public class ListContainObjectBase
    {
        public ListContainObjectBase(string id)
        {
            mId = id;
        }
        public string mId;
    }

    public static class ListExtension
    {
        public static bool ContainsStringKey<T>(this List<T> list, string id) where T : ListContainObjectBase
        {
           
            foreach(T i in list)
            {
                if(i.mId == id)
                {
                    return true;
                }
            }
            return false;
        }
        public static T GetStringKey<T>(this List<T> list, string id) where T : ListContainObjectBase
        {

            foreach (T i in list)
            {
                if (i.mId == id)
                {
                    return i;
                }
            }
            return null;
        }

        public static bool AddIfNotExistStringKey<T>(this List<T> list, string id) where T : ListContainObjectBase
        {
            T t = list.GetStringKey<T>(id);
            if (t != null)
            {
                return false;
            }
            else
            {
                T newt = Activator.CreateInstance(typeof(T),id) as T;
                list.Add(newt);

                return true;
            }

        }
        public static bool RemoveIfExistStringKey<T>(this List<T> list, string id) where T : ListContainObjectBase
        {
            T t = list.GetStringKey<T>(id);
            if (t != null)
            {
                list.Remove(t);
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
