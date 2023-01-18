using BossSpotted.Models.Interface;

namespace BossSpotted.Models.EntityFramework
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> query) where T : class?, IDbModel?
        {
            return query.Where(x => x.DeletedTimeStamp == null);
        }
        public static void MarkDeleted<T>(this T entity) where T : class?, IDbModel?
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.DeletedTimeStamp = DateTime.UtcNow;
        }
    }
}
