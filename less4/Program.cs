
using System;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;




var connectionString = "Data Source = SRV2\\PUPILS; Initial Catalog = 326380912_Person; Integrated Security = True; Trust Server Certificate=True";

using (SqlConnection s = new SqlConnection(connectionString))
{

    try
    {
        s.Open();
        Console.Write("Id: ");
        var Id = Console.ReadLine();
        Console.Write("\nFirstName: ");
        var FirstName = Console.ReadLine();
        Console.Write("\nLastName: ");
        var LastName = Console.ReadLine();
        Console.Write("\nPhone: ");
        var Phone = Console.ReadLine();
        Console.Write("\nEmail: ");
        var Email = Console.ReadLine();
        Console.Write("\nAddress: ");
        var Address = Console.ReadLine();
        Console.Write("\nDataOfBirth: ");
        var DateOfBirth = Console.ReadLine();


        //////////insert
        string queryString = $"insert into Details([Id],[FirstName],[LastName],[Phone],[Email],[Address],[DateOfBirth]) values(@Id, @FirstName,@LastName,@Phone,@Email,@Address,@DateOfBirth)";
        SqlCommand command_insert = new SqlCommand(queryString, s);
 
        var IdeParamter = new SqlParameter("@Id", Id);
        var FirstNameParamter = new SqlParameter("@FirstName", FirstName);
        var LastNameParamter = new SqlParameter("@LastName", LastName);
        var PhoneParamter = new SqlParameter("@Phone", Phone);
        var EmailParamter = new SqlParameter("@Email", Email);
        var AddressParamter = new SqlParameter("@Address", Address);
        var DateOfBirthParamter = new SqlParameter("@DateOfBirth", DateOfBirth);

        command_insert.Parameters.Add(IdeParamter);
        command_insert.Parameters.Add(FirstNameParamter);
        command_insert.Parameters.Add(LastNameParamter);
        command_insert.Parameters.Add(PhoneParamter);
        command_insert.Parameters.Add(EmailParamter);
        command_insert.Parameters.Add(AddressParamter);
        command_insert.Parameters.Add(DateOfBirthParamter);


        //////////delete
        Console.Write("Enter id to delete: ");
        var IdToDelete = Console.ReadLine();
        SqlCommand command_delete = new SqlCommand("delete from Details where Id=@IdToDelete", s);
        var IdToDeleteeParamter = new SqlParameter("@IdToDelete", IdToDelete);
        command_delete.Parameters.Add(IdToDeleteeParamter);

        //////////update
        Console.Write("Enter id to update: ");
        var IdToUpdate = Console.ReadLine();
        SqlCommand command_update = new SqlCommand("update Details set firstName='miri' where Id=@IdToUpdate", s);
        var IdToUpdateParamter = new SqlParameter("@IdToUpdate", IdToUpdate);
        command_update.Parameters.Add(IdToUpdateParamter);

       
            command_insert.ExecuteNonQuery();
            command_delete.ExecuteNonQuery();
            command_update.ExecuteNonQuery();
    }
    catch (SqlException ex)
    {
        Console.WriteLine("Eror: " + ex.Message);
    }

}
