using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.Winform.Queries
{
    public class Queries
    {
        internal static string createQuery { get; } = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        internal static string readQuery { get; } = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [DotNetCore].[dbo].[Tbl_Blog]";

        internal static string updateQuery { get; } = @"
        UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle,
            [BlogAuthor] = @BlogAuthor,
            [BlogContent] = @BlogContent
        WHERE BlogId = @BlogId";
    }
}
