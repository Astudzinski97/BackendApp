using System;

namespace BackendApp
{
    public class Person
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0}, FirstName: {1}, LastName: {2}, DateOfBirth: {3}", Id, FirstName, LastName, DateOfBirth);

        }
    }
}
