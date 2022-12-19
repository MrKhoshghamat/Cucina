namespace Cucina.SQL.Queries.Account;

public static class UserQueries
{
    public static string AllUsers => @"EXEC [dbo].[GetAllUsersOrGetUserById] @Id";

    public static string UserById => @"EXEC [dbo].[GetAllUsersOrGetUserById] @Id";

    public static string AddUser => @"EXEC [dbo].[AddOrUpdateUser] @Id, @RoleId, @UserName, @FirstName, @LastName, 
                                    @BirthDate, @Email, @Password, @RePassword, @Mobile, @Address, @Biography, 
                                    @SocialMedia, @EmailConfirmationCode,@SMSConfirmationCode, @IsEmailConfirmed, 
                                    @IsSMSConfirmed, @RegistrationDate,@ModificationDate, @IsDeleted";
    
    public static string UpdateUser => @"EXEC [dbo].[AddOrUpdateUser] @Id, @RoleId, @UserName, @FirstName, @LastName, 
                                       @BirthDate, @Email, @Password, @RePassword, @Mobile, @Address, @Biography, 
                                       @SocialMedia, @EmailConfirmationCode,@SMSConfirmationCode, @IsEmailConfirmed, 
                                       @IsSMSConfirmed, @RegistrationDate,@ModificationDate, @IsDeleted";

    public static string DeleteUser => @"EXEC [dbo].[DeleteUser] @Id";

    public static string IsExistUserByEmail => @"Select dbo.IsExistUserByEmail(@Email)";
}