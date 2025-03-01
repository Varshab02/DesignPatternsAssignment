namespace SqlQueriesBuilderDemo
{
    public class Query
    {
        public string SqlQuery { get; private set; }

        public Query(string sqlQuery)
        {
            SqlQuery = sqlQuery;
        }
        public override string ToString()
        {
            return SqlQuery;
        }
    }

}
