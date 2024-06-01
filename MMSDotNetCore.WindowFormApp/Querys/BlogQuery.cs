﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSDotNetCore.WindowFormApp.Querys
{
    public class BlogQuery
    {
        public static string BlogCreate { get; } = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle],
                            [BlogAuthor],
                            [BlogContent])
                            VALUES
                            (@BlogTitle,
                            @BlogAuthor,
                            @BlogContent)";

        public static string BlogRead { get; } = @"SELECT [BlogId]
                            ,[BlogTitle]
                            ,[BlogAuthor]
                            ,[BlogContent]
                            FROM [dbo].[Tbl_Blog]";
    }
}
