using System;
using System.Collections.Generic;
namespace SqlQueriesBuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ISqlQueryBuilder builder = new SqlQueryBuilder();
            QueryDirector director = new QueryDirector(builder);

            Console.WriteLine("Enter table name:");
            string table = Console.ReadLine();

            Console.WriteLine("Enter column names (comma-separated, e.g., Id,Name,Age):");
            string[] columns = Console.ReadLine().Split(',');

            Console.WriteLine("Enter condition (or press Enter to skip):");
            string condition = Console.ReadLine();
            condition = string.IsNullOrWhiteSpace(condition) ? null : condition;

            Console.WriteLine("Enter ORDER BY column (or press Enter to skip):");
            string orderBy = Console.ReadLine();
            orderBy = string.IsNullOrWhiteSpace(orderBy) ? null : orderBy;

            Console.WriteLine("Enter ORDER (ASC/DESC, default is ASC):");
            string order = Console.ReadLine();
            order = string.IsNullOrWhiteSpace(order) ? "ASC" : order.ToUpper();

            Console.WriteLine("Enter JOIN table name (or press Enter to skip):");
            string joinTable = Console.ReadLine();
            string joinCondition = null;
            string joinType = null;

            if (!string.IsNullOrWhiteSpace(joinTable))
            {
                Console.WriteLine($"Enter JOIN condition for {joinTable} (e.g., Employees.DepartmentId = Departments.Id):");
                joinCondition = Console.ReadLine();

                Console.WriteLine("Enter JOIN type (INNER, LEFT, RIGHT, FULL, default is INNER):");
                joinType = Console.ReadLine();
                joinType = string.IsNullOrWhiteSpace(joinType) ? "INNER" : joinType.ToUpper();
            }

            Console.WriteLine("Enter GROUP BY columns (comma-separated, or press Enter to skip):");
            string groupByInput = Console.ReadLine();
            string[] groupBy = string.IsNullOrWhiteSpace(groupByInput) ? null : groupByInput.Split(',');

            Query query = director.GenerateQuery(
                columns: columns,
                table: table,
                condition: condition,
                orderBy: orderBy,
                order: order,
                groupBy: groupBy,
                join: string.IsNullOrWhiteSpace(joinTable) ? null : (joinTable, joinCondition, joinType)
            );

            Console.WriteLine("\nGenerated SQL Query:");
            Console.WriteLine(query);
        }
    }
}

