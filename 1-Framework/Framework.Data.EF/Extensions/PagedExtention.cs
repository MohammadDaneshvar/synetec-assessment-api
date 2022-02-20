using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Data.EF.Extensions
{
    public static class PagedExtention
    {
        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int skip, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.RowCount = await query.CountAsync();
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }

}
