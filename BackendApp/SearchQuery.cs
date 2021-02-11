using System;

namespace BackendApp
{
    public class SearchQuery
    {
        public virtual string Keyword { get; set; }
        public virtual DateTime DateOfBirthFrom { get; set; }
        public virtual DateTime DateOfBirthTo { get; set; }

    }
}
