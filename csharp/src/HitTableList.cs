using System.Numerics;
using raytracing.DataStructures;

namespace raytracing.Extentions
{
    public static class HitListExtention
    {
        public static bool Hit<T>(this List<HitTable<T>> list, 
        Ray<T> ray, T min, T max, ref HitRecord<T> rec) where T : INumber<T>
        {
            HitRecord<T> tempRecord = default;
            bool didHit = false;
            T closestT = max;
            foreach (var table in list) {
                if(table.Hit(ray,min,closestT, ref tempRecord)) {
                    didHit = true;
                    closestT = tempRecord.T;
                    rec = tempRecord;
                }
            }
            return didHit;
        }
    }
}