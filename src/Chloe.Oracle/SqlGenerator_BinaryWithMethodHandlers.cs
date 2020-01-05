﻿using Chloe.DbExpressions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Chloe.Oracle
{
    partial class SqlGenerator : DbExpressionVisitor<DbExpression>
    {
        static Dictionary<MethodInfo, Action<DbBinaryExpression, SqlGenerator>> InitBinaryWithMethodHandlers()
        {
            var binaryWithMethodHandlers = new Dictionary<MethodInfo, Action<DbBinaryExpression, SqlGenerator>>();
            binaryWithMethodHandlers.Add(PublicConstants.MethodInfo_String_Concat_String_String, StringConcat);
            binaryWithMethodHandlers.Add(PublicConstants.MethodInfo_String_Concat_Object_Object, StringConcat);

            var ret = PublicHelper.Clone(binaryWithMethodHandlers);
            return ret;
        }

        static void StringConcat(DbBinaryExpression exp, SqlGenerator generator)
        {
            generator._sqlBuilder.Append("CONCAT(");
            exp.Left.Accept(generator);
            generator._sqlBuilder.Append(",");
            exp.Right.Accept(generator);
            generator._sqlBuilder.Append(")");
        }
    }
}
