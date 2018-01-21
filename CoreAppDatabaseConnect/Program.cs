using CoreAppDatabaseConnect.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Collections;

namespace CoreAppDatabaseConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=Delli5\SQLEx; Database = agdova; User id=sa;Password=info123!";

            
            using(var cont = new OfficeContext(connectionString)) {

                var data = cont.Reporters.ToListAsync();
                data.Wait();
                Console.WriteLine( data.Result.Count);
            }

        }
    }
}
