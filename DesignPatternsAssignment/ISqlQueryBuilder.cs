
namespace SqlQueriesBuilderDemo
{
    public interface ISqlQueryBuilder
    {
        ISqlQueryBuilder Select(params string[] columns);
        ISqlQueryBuilder From(string table);
        ISqlQueryBuilder Where(string condition);
        ISqlQueryBuilder OrderBy(string column, string order);
        ISqlQueryBuilder GroupBy(params string[] columns);
        ISqlQueryBuilder Join(string table, string onCondition, string joinType = "INNER");
        Query Build();
    }

}
