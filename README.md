# DatabaseMigrationsTest

參考了這篇文的範例專案，把各別的的版本都提到了.net core 5，不過沒有去研究RoundHouseE，感覺太冷門。

https://surfingthecode.com/5-ways-to-manage-database-schema-changes-in-.net/

另一篇介紹Database Migration的理論，也可參考。

http://www.kamilgrzybek.com/database/using-database-project-and-dbup-for-database-management/

1. DatabaseMigrationsTest.DbUp
   使用原生的sql進行資料庫更版，沒有退版這種事，用Sql可以進行比較精細的更版。
2. DatabaseMigrationsTest.EntityFramework
   這應該是最多人用的方式，只是一定要搭配Entity Framework。更新EF的Model，自動產生更新的程式碼。
3. DatabaseMigrationsTest.FluentMigrator
   類似EF的更版方式，只是自己寫更新的程式，但是用C#來寫。
4. DatabaseMigrationsTest.SqlServerDataTools
   用介面修改Schema，再發行出去
