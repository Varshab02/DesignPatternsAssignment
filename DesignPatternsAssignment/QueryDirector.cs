using System;
namespace SqlQueriesBuilderDemo
{
    public class QueryDirector
    {
        private ISqlQueryBuilder _builder;

        public QueryDirector(ISqlQueryBuilder builder)
        {
            _builder = builder;
        }

        public Query GenerateQuery(string[] columns, string table, string? condition = null, string? orderBy = null,
                                   string? order = "ASC", string[]? groupBy = null,
                                   (string table, string condition, string joinType)? join = null)
        {
            _builder.Select(columns).From(table);

            if (join.HasValue)
                _builder.Join(join.Value.table, join.Value.condition, join.Value.joinType);

            if (!string.IsNullOrEmpty(condition))
                _builder.Where(condition);

            if (groupBy != null && groupBy.Length > 0)
                _builder.GroupBy(groupBy);

            if (!string.IsNullOrEmpty(orderBy))
                _builder.OrderBy(orderBy, order);

            return _builder.Build();
        }
    }


}
