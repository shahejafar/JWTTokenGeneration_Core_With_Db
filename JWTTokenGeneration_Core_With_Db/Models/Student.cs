﻿namespace JWTTokenGeneration_Core_With_Db.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }
        public string Gendre { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
