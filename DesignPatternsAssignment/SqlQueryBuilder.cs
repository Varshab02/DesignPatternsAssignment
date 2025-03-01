
using System;
using System.Text;

namespace SqlQueriesBuilderDemo
{
    public class SqlQueryBuilder : ISqlQueryBuilder
    {
        private StringBuilder queryBuilder = new StringBuilder();
        private bool hasSelect = false;
        private bool hasFrom = false;
        public ISqlQueryBuilder Select(params string[] columns)
        {
            if (columns.Length == 0)
                throw new ArgumentException("At least one column must be selected.");

            queryBuilder.Append("SELECT " + string.Join(", ", columns) + " ");
            hasSelect = true;
            return this;
        }

        public ISqlQueryBuilder From(string table)
        {
            if (!hasSelect)
                throw new InvalidOperationException("SELECT must be specified before FROM.");

            queryBuilder.Append($"FROM {table} ");
            hasFrom = true;
            return this;
        }

        public ISqlQueryBuilder Where(string condition)
        {
            if (!hasFrom)
                throw new InvalidOperationException("FROM must be specified before WHERE.");

            queryBuilder.Append($"WHERE {condition} ");
            return this;
        }

        public ISqlQueryBuilder OrderBy(string column, string order = "ASC")
        {
            queryBuilder.Append($"ORDER BY {column} {order} ");
            return this;
        }

        public ISqlQueryBuilder GroupBy(params string[] columns)
        {
            if (columns.Length > 0)
                queryBuilder.Append("GROUP BY " + string.Join(", ", columns) + " ");
            return this;
        }

        public ISqlQueryBuilder Join(string table, string onCondition, string joinType = "INNER")
        {
            if (!hasFrom)
                throw new InvalidOperationException("FROM must be specified before JOIN.");

            queryBuilder.Append($"{joinType.ToUpper()} JOIN {table} ON {onCondition} ");
            return this;
        }

        public Query Build()
        {
            return new Query(queryBuilder.ToString().TrimEnd());
        }
    }


}
