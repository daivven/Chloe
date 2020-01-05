﻿using Chloe.DbExpressions;

namespace Chloe.SqlServer.MethodHandlers
{
    class DiffMilliseconds_Handler : IMethodHandler
    {
        public bool CanProcess(DbMethodCallExpression exp)
        {
            if (exp.Method.DeclaringType != PublicConstants.TypeOfSql)
                return false;

            return true;
        }
        public void Process(DbMethodCallExpression exp, SqlGenerator generator)
        {
            SqlGenerator.DbFunction_DATEDIFF(generator, "MILLISECOND", exp.Arguments[0], exp.Arguments[1]);
        }
    }
}
