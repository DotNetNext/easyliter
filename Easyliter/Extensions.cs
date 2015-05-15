using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Easyliter
{
    public static class Extensions
    {
        public static El_Queryable<T> Where<T>(this El_Queryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            string whereStr = string.Empty;

            if (expression.Body is BinaryExpression)
            {
                BinaryExpression be = ((BinaryExpression)expression.Body);
                whereStr = " and " + Common.BinarExpressionProvider(be.Left, be.Right, be.NodeType);
            }
            queryable.QueryItemList.Last().AppendValues.Add(whereStr);
            return queryable;
        }
        public static El_Queryable<T> Skip<T>(this El_Queryable<T> queryable, int skipNum)
        {
            var item = queryable.QueryItemList.Last();
            if (item.Skip == null)
            {
                item.Skip = skipNum;
            }
            else
            {
                throw new Exception("不能对同一张表多次skip");
            }
            return queryable;
        }
        public static El_Queryable<T> Take<T>(this El_Queryable<T> queryable, int takeNum)
        {
            var item = queryable.QueryItemList.Last();
            if (item.Take == null)
            {
                item.Take = takeNum;
            }
            else
            {
                throw new Exception("不能对同一张表多次takeNum");
            }
            return queryable;
        }
        public static El_Queryable<T> Select<T>(this El_Queryable<T> queryable, string selectRow)
        {
            if (selectRow != null)
            {
                var item = queryable.QueryItemList.Last();
                item.SelectRow = selectRow;
            }
            return queryable;
        }
        public static El_Queryable<T> OrderBy<T>(this El_Queryable<T> queryable, El_Sort sortType, string sortField)
        {
            var isAsc = sortType == El_Sort.asc;
            var item = queryable.QueryItemList.Last();
            var isFirst = item.OrderBy == null;
            if (isFirst)
            {
                item.OrderBy = " order by ";
            }
            else
            {
                item.OrderBy += ",";
            }
            item.OrderBy += isAsc ? string.Format(" {0} asc", sortField) : string.Format(" {0} desc", sortField);
            item.OrderBy = item.OrderBy;
            return queryable;
        }

        public static string ToSql<T>(this El_Queryable<T> entity) where T : new()
        {
            StringBuilder sql = new StringBuilder();
            if (entity == null || entity.QueryItemList.Count == 0)
            {
                return string.Format("select * from {0}", new T().GetType().Name);
            }
            else
            {
                foreach (var r in entity.QueryItemList)
                {
                    sql.AppendFormat(" select {1} from {0} where 1=1 ", r.TableName, r.SelectRow == null ? "*" : r.SelectRow);
                    foreach (var appendValue in r.AppendValues)
                    {
                        sql.Append(appendValue);
                    }
                    sql.Append(r.OrderBy);
                    if (r.Skip == null && r.Take == null)
                    {

                    }
                    else if (r.Skip != null && r.Take != null)
                    {
                        sql.AppendFormat(" limit {0},{1} ", r.Skip, r.Take);
                    }
                    else if (r.Take != null)
                    {
                        sql.AppendFormat(" limit 0,{0} ", r.Take);
                    }
                    else
                    {
                        sql.AppendFormat("limit {0},{1} ", r.Skip, int.MaxValue);
                    }
                }
                return sql.ToString();
            }
        }

        public static List<T> ToList<T>(this El_Queryable<T> entity) where T : new()
        {
            string sql = entity.ToSql();
            return entity.e.Select<T>(sql);

        }
    }
}
